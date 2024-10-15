using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace officeeatsbackendapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("Welcome to OfficeEats API!");
        }
    }
}
