﻿
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using officeeatsbackendapi.Services;

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
        public async Task<ActionResult<bool>> ChangePassword([FromBody] ChangePasswordDto changePassword)
        {
            try
            {
                var results = await _usersService.ChangePasswordAsync(changePassword);

                if (!results)
                {
                    return BadRequest(false);
                }

                return StatusCode(200, true);
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
        //public async Task<IActionResult> UpdateUser([FromBody] UsersDto user)
        //{

            //try
            //{
                //await _usersService.UpdateUserAsync(user);
                //return StatusCode(200, user);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { message = "Internal server error" });
            //}
        //}

        [HttpPut("users/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UsersDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest("User ID mismatch.");
            }

            var result = await _usersService.UpdateUser(userDto);
           
            if (!result)
            {
                return NotFound("User not found or failed to update.");
            }

            return StatusCode(200, result);
        }

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
