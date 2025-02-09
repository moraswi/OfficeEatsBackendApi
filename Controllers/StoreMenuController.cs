using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using officeeatsbackendapi.Services;
using OfficeEatsBackendApi.Models;

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


        [HttpPost("questionnaire-title")]
        public async Task<IActionResult> AddQuestionnaireTitlesAsync([FromBody] QuestionnaireTitles titles)
        {
            try
            {
                var results = await _storeMenuService.AddQuestionnaireTitlesAsync(titles);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("questionnaire-option")]
        public async Task<IActionResult> AddQuestionnaireOptionsAsync([FromBody] QuestionnaireOptions options)
        {
            try
            {
                var results = await _storeMenuService.AddQuestionnaireOptionsAsync(options);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("store-menu/images")]
        public async Task<IActionResult> AddStoreMenuImages([FromBody] StoreMenuImages image)
        {
            try
            {
                var results = await _storeMenuService.AddStoreMenuImagesAsync(image);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPost("order-customization")]
        public async Task<IActionResult> AddOrderCustomizations([FromBody] OrderCustomizations customization)
        {
            //try
            //{
                var results = await _storeMenuService.AddOrderCustomizationsAsync(customization);
                return StatusCode(200, results);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, new { message = "Internal server error" });
            //}
        }

        [HttpGet("order-customizations-byiteiId/{itemId}")]
        public async Task<IActionResult> getOrderCustomizationsByItemIdAsync([FromRoute] int itemId)
        {
            try
            {
                var results = await _storeMenuService.getOrderCustomizationsByItemIdAsync(itemId);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("questionnaire-title/{storemenuid}")]
        public async Task<IActionResult> getQuestionnaireTitlesAsync([FromRoute] int storemenuid)
        {
            try
            {
                var results = await _storeMenuService.getQuestionnaireTitlesAsync(storemenuid);
                return StatusCode(200, results);
        }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }

        }

        [HttpGet("store-menu/images/{storemenuid}")]
        public async Task<IActionResult> GetStoreMenuImages([FromRoute] int storemenuid)
        {
            try
            {
                var results = await _storeMenuService.GetStoreMenuImagesAsync(storemenuid);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("store-menu/category/{categoryid}")]
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

        [HttpGet("store-menu/{storeid}")]
        public async Task<IActionResult> GetStoreMenueByStoreId([FromRoute] int storeid)
        {
            try
            {
                var results = await _storeMenuService.GetStoreMenueByStoreIdAsync(storeid);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }


        [HttpGet("store-menu/promotion-meals/{storeid}")]
        public async Task<IActionResult> GetStorePromotionMenueByStoreId([FromRoute] int storeid)
        {
            try
            {
                var results = await _storeMenuService.GetStorePromotionMenueByStoreIdAsync(storeid);
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
