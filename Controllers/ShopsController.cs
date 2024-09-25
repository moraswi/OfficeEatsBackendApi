using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Services;

namespace officeeatsbackendapi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        #region Fields
        private readonly IShopServices _shopServices;
        #endregion Fields

        #region Public Constructors
        public ShopsController(IShopServices shopServices)
        {
            _shopServices = shopServices;
        }
        #endregion Public Constructors

        [HttpPost("shop")]
        public async Task<IActionResult> AddShop([FromBody] ShopsDto shops)
        {
            try
            {
                var results = await _shopServices.AddShopAsync(shops);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
