using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Services;

namespace officeeatsbackendapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RateController : ControllerBase
    {
        #region Fields
        private readonly IRateServices _rateServices;
        #endregion Fields

        #region Public Constructors
        public RateController(IRateServices rateServices)
        {
            _rateServices = rateServices;
        }
        #endregion Public Constructors


        [HttpPost("rate")]
        public async Task<IActionResult> AddRating([FromBody] RateDto rateDto)
        {
            //try
            //{
                var results = await _rateServices.AddRatingAsync(rateDto);
                return StatusCode(200, results);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { message = "Internal server error" });
            //}
        }
    }
}
