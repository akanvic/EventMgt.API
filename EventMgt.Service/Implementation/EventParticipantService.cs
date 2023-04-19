using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
using EventMgt.Repo.Data.GenericRepository.Interface;
using EventMgt.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Implementation
{
    public class EventParticipantService : IEventParticipantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventParticipantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> EventRegistration(EventParticipantDTO eventParticipantDTO)
        {

            var eventParticipantObj = new EventParticipant
             {
                 EventId = eventParticipantDTO.EventId,
                 ParticipantId = eventParticipantDTO.ParticipantId,
                 EventParticipantStatus = true,
             };
            var userResponse = await _unitOfWork.UsersRepository.FirstOrDefaultAsync(c => c.UserId == eventParticipantDTO.ParticipantId);
            if (userResponse is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error Registering for this Event, Participant user does not exist", Data = userResponse };

            var eventResponse = await _unitOfWork.EventsRepository.FirstOrDefaultAsync(c => c.EventId == eventParticipantDTO.EventId);
            if (eventResponse is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error Registering for this Event, Event does not exist", Data = eventResponse};
            
            var eventParticipantResponse = await _unitOfWork.EventParticipantsRepository
                .FirstOrDefaultAsync(c => c.EventId == eventParticipantDTO.EventId &&
                c.ParticipantId==eventParticipantDTO.ParticipantId && c.EventParticipantStatus == true);

            if(eventParticipantResponse is not null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "User has an active registration for this Event"};

            var response = await _unitOfWork.EventParticipantsRepository.CreateAsync(eventParticipantObj);

             var ret = await _unitOfWork.Save();

             if (ret < 0)
                 return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error Registering for this Event", Data = ret };

             return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Event Registration successful", Data = response };
        }

        public async Task<ResponseModel> UpdateParticipantEventStatus(int eventParticipantId)
        {
            var response = await _unitOfWork.EventParticipantsRepository.UpdateParticipantEventStatus(eventParticipantId);

            if (response is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Event Does not Exist For the user", Data = response };

            var ret = await _unitOfWork.Save();

            if (ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error updating participants events status", Data = ret };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "User has successfully been deregistered from this event", Data = response };
        }
    }
}
