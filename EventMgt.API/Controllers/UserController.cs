using EventMgt.Core.DTOS;
using EventMgt.Core.Models;
using EventMgt.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventMgt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserService _userService;
        public UserController(IApplicationUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(ApplicationUser applicationUser)
        {
            try
            {
                var response = await _userService.AddUser(applicationUser);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var response = await _userService.GetAllUsers();
                if (response is null)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }

        [HttpGet("GetUserInfo")]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            try
            {
                var response = await _userService.GetUserInfo(id);
                if (response is null)
                    return BadRequest(response);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex?.InnerException?.InnerException?.Message ?? ex?.InnerException?.Message ?? ex?.Message);
            }
        }
    }
}
