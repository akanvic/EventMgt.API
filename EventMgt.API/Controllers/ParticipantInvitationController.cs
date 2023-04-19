using EventMgt.Core.DTOS;
using EventMgt.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantInvitationController : ControllerBase
    {
        private readonly IParticipantInvitationService _participantInvitationService;
        public ParticipantInvitationController(IParticipantInvitationService participantInvitationService)
        {
            _participantInvitationService = participantInvitationService;
        }

        [HttpPost("SendInvitation")]
        public async Task<IActionResult> SendInvitation(SendInvitationDTO sendInvitationDTO)
        {
            try
            {
                var response = await _participantInvitationService.SendInvitation(sendInvitationDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("GetInvitations")]
        public async Task<IActionResult> GetInvitations(int participantId)
        {
            try
            {
                var response = await _participantInvitationService.GetInvitations(participantId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("AcceptInvitation")]
        public async Task<IActionResult> AcceptInvitation(int participantInvitationId)
        {
            try
            {
                var response = await _participantInvitationService.AcceptInvitation(participantInvitationId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

    }
}
