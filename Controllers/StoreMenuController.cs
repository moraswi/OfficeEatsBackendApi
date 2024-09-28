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
    public class StoreMenuController : ControllerBase
    {
        #region Fields
        private readonly IStoreMenuService _storeMenuService;
        #endregion Fields

        #region Public Constructors
        public StoreMenuController(IStoreMenuService storeMenuService)
        {
            _storeMenuService = storeMenuService;
        }
        #endregion Public Constructors

        [HttpPost("store-menu")]
        public async Task<IActionResult> AddStoreMenu([FromBody] StoreMenuDto storeMenu)
        {
            try
            {
                var results = await _storeMenuService.AddStoreMenueAsync(storeMenu);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("store-menu/{categoryid}")]
        public async Task<IActionResult> GetStoreMenuByCategoryId([FromRoute] int categoryid)
        {
            try
            {
                var results = await _storeMenuService.GetStoreMenueByCategoryIdAsync(categoryid);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPut("store-menu")]
        public async Task<IActionResult> UpdateStoreMenu([FromBody] StoreMenu storeMenu)
        {
            try
            {
                var results = await _storeMenuService.UpdateStoreMenuAsync(storeMenu);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpDelete("store-menu/{id}")]
        public async Task<IActionResult> DeleteStoreMenu([FromRoute] int id)
        {
            try
            {
                var results = await _storeMenuService.DeleteStoreMenueAsync(id);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
