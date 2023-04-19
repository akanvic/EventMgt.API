using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Repo.Data.GenericRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Repo.Data.Repository.Interface
{
    public interface IEventRepository : IGenericRepository<Event>
    {
        Task<Event> UpdateEvent(EventDTO eventDTO);
        Task<Event> GetEventInfo(int eventId);
    }
}
