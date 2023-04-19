using EventMgt.Core.DTOS;
using EventMgt.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Interface
{
    public interface IEventParticipantService
    {
        Task<ResponseModel> EventRegistration(EventParticipantDTO eventParticipantDTO);
        Task<ResponseModel> UpdateParticipantEventStatus(int eventParticipantId);
    }
}
