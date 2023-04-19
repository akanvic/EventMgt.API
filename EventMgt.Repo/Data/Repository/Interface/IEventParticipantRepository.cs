using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Core.Responses;
using EventMgt.Repo.Data.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.Repository.Interface
{
    public interface IEventParticipantRepository : IGenericRepository<EventParticipant>
    {
        Task<EventParticipant> UpdateParticipantEventStatus(int eventParticipantId);
    }
}
