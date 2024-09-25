using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Services;

namespace officeeatsbackendapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class OfficeController : ControllerBase
    {

        #region Fields
        private readonly IOfficesServices _officesServices;
        #endregion Fields

        #region Public Constructors
        public OfficeController(IOfficesServices officesServices)
        {
            _officesServices = officesServices;
        }
        #endregion Public Constructors


        [HttpPost("office")]
        public async Task<IActionResult> AddOffice([FromBody] OfficesDto Offices)
        {
            try
            {
                var results = await _officesServices.AddOfficeAsync(Offices);
                return StatusCode(200, results);
        }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("offices")]
        public async Task<IActionResult> GetAllOffices()
        {
            try
            {
                var results = await _officesServices.GetAllOfficesAsync();
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

    }
}
