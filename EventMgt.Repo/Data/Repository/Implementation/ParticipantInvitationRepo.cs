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
    public class ParticipantInvitationRepo : GenericRepository<ParticipantInvitation>, IParticipantInvitationRepo
    {
        private readonly EventMgtContext _eventMgtContext;
        public ParticipantInvitationRepo(EventMgtContext eventMgtContext) : base(eventMgtContext)
        {
            _eventMgtContext = eventMgtContext;
        }

        public async Task<ParticipantInvitation> AcceptInvitation(int participantInvitationId)
        {
            var response = await _eventMgtContext.ParticipantInvitations
                .FirstOrDefaultAsync(c => c.ParticipantInvitationId == participantInvitationId);

            if (response != null)
            {
                response.EventInvitationStatus = true;
            }
            return response;
        }
    }
}
