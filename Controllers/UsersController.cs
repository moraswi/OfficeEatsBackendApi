﻿
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
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
                var response = await _usersService.RegisterUserAsync(registerUser);

                if (!response.Success)
                {
                    return StatusCode(400, new { message = response.Message });
                }

                return StatusCode(200, registerUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDto logInDto)
        {
            var response = await _usersService.LogInAsync(logInDto);

            if (!response.Success)
            {
                return StatusCode(400, new { message = response.Message });
            }

            return StatusCode(200, response.Data);
        }


        [HttpPost("change-password")]
        public async Task<bool> ChangePassword([FromBody] ChangePasswordDto changePassword)
        {
            try
            {
                var results = await _usersService.ChangePasswordAsync(changePassword);
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
                return StatusCode(500, new { message = "Internal server error" });
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
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        //[HttpPut("users")]
        //public async Task<IActionResult> UpdateUser([FromBody] UsersDto user) {

        //    try
        //    {
        //        await _usersService.UpdateUserAsync(user);
        //        return StatusCode(200, user);
        //}
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Internal server error" });
        //    }
        //}

        [HttpDelete("user/{userid}")]
        public async Task<bool> DeleteUser(int userid)
        {
            try
            {
                var results = await _usersService.DeleteUserAsync(userid);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
