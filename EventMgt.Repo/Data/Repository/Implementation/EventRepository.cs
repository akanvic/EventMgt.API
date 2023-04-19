using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Repo.Data.GenericRepository.Implementation;
using EventMgt.Repo.Data.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.Repository.Implementation
{
    public class EventRepository : GenericRepository<Event>, IEventRepository
    {
        private readonly EventMgtContext _eventMgtContext;
        public EventRepository(EventMgtContext eventMgtContext) : base(eventMgtContext)
        {
            _eventMgtContext = eventMgtContext;
        }
        public async Task<Event> UpdateEvent(EventDTO eventDTO)
        {
            var response = await _eventMgtContext.Events
                .FirstOrDefaultAsync(c => c.EventId == eventDTO.EventId && c.EventCreatorId.Equals(eventDTO.EventCreatorId));
            if(response != null)
            {
                response.EventTitle = eventDTO.EventTitle;
                response.EventStartDate = eventDTO.EventStartDate;
                response.EventEndDate = eventDTO.EventEndDate;
                response.EventDescription = eventDTO.EventDescription;
            }
            return response;
        }
        public async Task<Event> GetEventInfo(int eventId)
        {
            var response =  await (from a in _eventMgtContext.Events
                        join b in _eventMgtContext.ApplicationUsers
                        on a.EventCreatorId equals b.UserId
                        select new Event
                        {
                            EventId = a.EventId,
                            EventTitle = a.EventTitle,
                            EventStartDate = a.EventStartDate,
                            EventDescription = a.EventDescription,
                            EventCreatorId = a.EventCreatorId,
                            EventCreator = b
                        }).FirstOrDefaultAsync(c => c.EventId == eventId);

            //var response = await _eventMgtContext.Events
            //    .FirstOrDefaultAsync(c => c.EventId == eventDTO.EventId && c.EventCreatorId.Equals(eventDTO.UserId));
            return response;
        }
    }
}
