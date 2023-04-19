using EventMgt.Core.DTOS;
using EventMgt.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost("AddEvent")]
        public async Task<IActionResult> AddEvent(EventDTO eventDTO)
        {
            try
            {
                var response = await _eventService.AddEvent(eventDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("UpdateEvent")]
        public async Task<IActionResult> UpdateEvent(EventDTO eventDTO)
        {
            try
            {
                var response = await _eventService.UpdateEvent(eventDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("ListOfCurrentUsersEvent")]
        public async Task<IActionResult> ListOfCurrentUsersEvent(ListOfCurrentUsersEventDTO currentUsersEventDTO)
        {
            try
            {
                var response = await _eventService.ListOfCurrentUsersEvent(currentUsersEventDTO);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("GetEventInfo")]
        public async Task<IActionResult> GetEventInfo(int eventId)
        {
            try
            {
                var response = await _eventService.GetEventInfo(eventId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpPost("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(int eventId)
        {
            try
            {
                var response = await _eventService.DeleteEvent(eventId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }
    }
}
