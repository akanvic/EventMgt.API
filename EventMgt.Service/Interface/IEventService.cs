using EventMgt.Core.DTOS;
using EventMgt.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Interface
{
    public interface IEventService
    {
        Task<ResponseModel> AddEvent(EventDTO eventDTO);
        Task<ResponseModel> UpdateEvent(EventDTO eventDTO);
        //Task<ResponseModel> DeleteEvent(EventDTO eventDTO);
        Task<ResponseModel> ListOfCurrentUsersEvent(ListOfCurrentUsersEventDTO currentUsersEventDTO);
        Task<ResponseModel> GetEventInfo(int eventId);
        Task<ResponseModel> DeleteEvent(int eventId);
    }
}
