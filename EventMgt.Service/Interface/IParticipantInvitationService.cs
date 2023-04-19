using EventMgt.Core.DTOS;
using EventMgt.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Service.Interface
{
    public interface IParticipantInvitationService
    {
        Task<ResponseModel> SendInvitation(SendInvitationDTO sendInvitationDTO);
        Task<ResponseModel> GetInvitations(int participantId);
        Task<ResponseModel> AcceptInvitation(int participantInvitationId);
    }
}
