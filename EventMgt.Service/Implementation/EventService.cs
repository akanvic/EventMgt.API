using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
using EventMgt.Repo.Data.GenericRepository.Interface;
using EventMgt.Service.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Implementation
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMemoryCache _cache;
        public EventService(IUnitOfWork unitOfWork, IMemoryCache cache)
        {
            _unitOfWork = unitOfWork;
            _cache = cache;
        }
        public async Task<ResponseModel> AddEvent(EventDTO eventDTO)
        {
            var userResponse = await _unitOfWork.UsersRepository
                .FirstOrDefaultAsync(c => c.UserId == eventDTO.EventCreatorId);

            if(userResponse is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Event Creator Id does not exist", Data = userResponse };

            var eventObj = new Event
            {
                EventTitle = eventDTO.EventTitle,
                EventStartDate = eventDTO.EventStartDate,
                EventEndDate = eventDTO.EventEndDate,
                EventDescription = eventDTO.EventDescription,
                EventCreatorId = eventDTO.EventCreatorId,
            };
            var response = await _unitOfWork.EventsRepository.CreateAsync(eventObj);

            var ret = await _unitOfWork.Save();

            if (ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error creating Event", Data = ret };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Event created successfully", Data = response };
        }

        public async Task<ResponseModel> DeleteEvent(int eventId)
        {
            _unitOfWork.EventsRepository.Remove(eventId);

            var ret = await _unitOfWork.Save();

            if (ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error deleting Event", Data = ret };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Event deleted successfully", Data = ret};
        }

        public async Task<ResponseModel> ListOfCurrentUsersEvent(ListOfCurrentUsersEventDTO currentUsersEventDTO)
        {

            var eventCache = _cache.Get<ResponseModel>("events");
            if (eventCache is not null) return eventCache;

            var userResponse = await _unitOfWork.UsersRepository
                .FindByConditionAsync(c => c.UserId == currentUsersEventDTO.UserId, true);

            if (userResponse is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "User does not exist in the Application", Data = userResponse };

            var response = await _unitOfWork.EventsRepository.FindByConditionAsync(c => c.EventCreatorId == currentUsersEventDTO.UserId, true);

            var eventResponse = response
                .OrderBy(on => on.EventTitle)
                .Skip((currentUsersEventDTO.pagination.PageNumber - 1) * currentUsersEventDTO.pagination.PageSize)
                .Take(currentUsersEventDTO.pagination.PageSize)
                .ToList();

            if (response is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "User does not have any Events scheduled", Data = eventResponse };

            var responseModel = new ResponseModel
            {
                StatusCode = HttpStatusCode.OK,
                Msg = "User Events Loaded Successfully",
                Data = eventResponse
            };
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(10))
                .SetSlidingExpiration(TimeSpan.FromSeconds(30))
                .SetSize(1024);
                
            _cache.Set("events", responseModel, cacheOptions);
            return responseModel;
        }
        public async Task<ResponseModel> GetEventInfo(int eventId)
        {
            var response = await _unitOfWork.EventsRepository.GetEventInfo(eventId);

            if (response is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Events does not exist", Data = response };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Events Info Loaded Successfully", Data = response };
        }

        public async Task<ResponseModel> UpdateEvent(EventDTO eventDTO)
        {
            var response = await _unitOfWork.EventsRepository.UpdateEvent(eventDTO);

            if (response == null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Event Does not Exist For the user Specified", Data = response };

            var ret = await _unitOfWork.Save();

            if (ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error Updating Event", Data = ret };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Event updated successfully", Data = response };
        }
    }
}
