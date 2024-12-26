using DepartmentManger.BL.DTOs.AppUSerDTOs;
using DepartmentManger.BL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        public readonly IAppUserService _appuser;

        public AppUsersController(IAppUserService appuser)
        {
            _appuser = appuser;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] AppUSerDto appUserDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status201Created, await _appuser.RegisterAsync(appUserDto));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);
            }
            try
            {
                return StatusCode(StatusCodes.Status200OK, await _appuser.LoginAsync(appUserLoginDto));
            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}
