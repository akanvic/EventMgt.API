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
    public class ParticipantInvitationService : IParticipantInvitationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ParticipantInvitationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseModel> AcceptInvitation(int participantInvitationId)
        {
            var response = await _unitOfWork.ParticipantInvitationsRepo.AcceptInvitation(participantInvitationId);
                        
            if(response is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Invitation does not exist", Data = response };

            var ret = await _unitOfWork.Save();

            if(ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error Accepting Invitation", Data = ret };
            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Invitation Accepted Successfully", Data = response };
        }

        public async Task<ResponseModel> GetInvitations(int participantId)
        {
            //Revisit
            var response = await _unitOfWork.ParticipantInvitationsRepo.FindByConditionAsync(c => c.ParticipantId == participantId, true);

            if (response is null)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "User does not have any Event Invitations", Data = response };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "User Invitations loaded successfully", Data = response };
        }

        public async Task<ResponseModel> SendInvitation(SendInvitationDTO sendInvitationDTO)
        {
            /*var participantResponse = await _unitOfWork.ParticipantInvitationsRepo
                .FindByConditionAsync(c => c.EventCreatorId == sendInvitationDTO.EventCreatorId &&
                                      c.EventId == sendInvitationDTO.EventId &&
                                      sendInvitationDTO.ParticipantIds.Contains(c.ParticipantId), true);
                */
            ParticipantInvitation response = null;
            foreach (var participant in sendInvitationDTO.ParticipantIds)
            {
                var participantInvitationObj = new ParticipantInvitation
                {
                    ParticipantId = participant,
                    EventCreatorId = sendInvitationDTO.EventCreatorId,
                    EventId = sendInvitationDTO.EventId,
                    EventInvitationStatus = false
                };
                response = await _unitOfWork.ParticipantInvitationsRepo.CreateAsync(participantInvitationObj);
            }
            var ret = await _unitOfWork.Save();

            if (ret < 0)
                return new ResponseModel { StatusCode = HttpStatusCode.BadRequest, Msg = "Error Sending Invitation to Participants", Data = ret };

            return new ResponseModel { StatusCode = HttpStatusCode.OK, Msg = "Invitation Sent Successfully", Data = response };
        }
    }
}
