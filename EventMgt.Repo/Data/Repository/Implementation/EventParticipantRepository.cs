using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
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
    public class EventParticipantRepository : GenericRepository<EventParticipant>, IEventParticipantRepository
    {
        private readonly EventMgtContext _eventMgtContext;
        public EventParticipantRepository(EventMgtContext eventMgtContext) : base(eventMgtContext)
        {
            _eventMgtContext = eventMgtContext;
        }
        public async Task<EventParticipant> UpdateParticipantEventStatus(int eventParticipantId)
        {
            var response = await _eventMgtContext.EventParticipants
                .FirstOrDefaultAsync(c => c.EventParticipantId == eventParticipantId);
            if (response != null)
            {
                response.EventParticipantStatus = false;
            }
            return response;
        }
    }
}
