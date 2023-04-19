using EventMgt.Core.DTOS;
using EventMgt.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventParticipantController : ControllerBase
    {
        private readonly IEventParticipantService _eventParticipantService;
        public EventParticipantController(IEventParticipantService eventParticipantService)
        {
            _eventParticipantService = eventParticipantService;
        }

        [HttpPost("EventRegistration")]
        public async Task<IActionResult> EventRegistration(EventParticipantDTO eventParticipantDTO)
        {
            try
            {
                var response = await _eventParticipantService.EventRegistration(eventParticipantDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("EventDeregistration")]
        public async Task<IActionResult> UpdateParticipantEventStatus(int eventParticipantId)
        {
            try
            {
                var response = await _eventParticipantService.UpdateParticipantEventStatus(eventParticipantId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }
    }
}
    