using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get-all-users")]
        public async Task<IActionResult> GetAllUsers() {
        
            var results = await _usersService.GetAllUsersAsync();
            return StatusCode(200, results);
        }
    }
}
