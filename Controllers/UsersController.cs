using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace pepbackendapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        #region Fields
        private readonly IUsersService _usersService;
        #endregion Fields

        #region Public Constructors
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        #endregion Public Constructors

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUser) {

            try
            {
                await _usersService.RegisterUserAsync(registerUser);
                return StatusCode(200, registerUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var results = await _usersService.GetAllUsersAsync();
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("user/{userid}")]
        public async Task<IActionResult> GetUserByUserId(int userid)
        {
            try
            {
                var results = await _usersService.GetUserByUserIdAsync(userid);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
