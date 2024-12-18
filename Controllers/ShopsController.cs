using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
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

        [HttpPost("store")]
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

        [HttpPost("store/image")]
        public async Task<IActionResult> AddShopImageAsync([FromBody] StoreImages image)
        {
            try
            {
                var results = await _shopServices.AddShopImageAsync(image);
                return StatusCode(200, results);
        }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("store/image/{storeId}")]
        public async Task<IActionResult> GetShopImage([FromRoute] int storeId)
        {
            try
            {
                var results = await _shopServices.GetShopImageAsync(storeId);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("stores/{officeid}")]
        public async Task<IActionResult> GetShopByOfficeId([FromRoute] int officeid)
        {
            //try
            //{
                var results = await _shopServices.GetShopByOfficeIdAsync(officeid);
                return StatusCode(200, results);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { message = "Internal server error" });
            //}
        }
    }
}
