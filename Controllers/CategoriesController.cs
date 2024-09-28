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
    public class CategoriesController : ControllerBase
    {
        #region Fields
        private readonly ICategoriesService _categoriesService;
        #endregion Fields

        #region Public Constructors
        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        #endregion Public Constructors

        [HttpPost("category")]
        public async Task<IActionResult> AddCategory([FromBody] CategoriesDto categoriesDto)
        {
            try
            {
                var results = await _categoriesService.AddCategoriesAsync(categoriesDto);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("category/{storeid}")]
        public async Task<IActionResult> GetCategoriesByStoreIdAsync([FromRoute] int storeid)
        {
            try
            {
                var results = await _categoriesService.GetCategoriesByStoreIdAsync(storeid);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        //[HttpPut("address")]
        //public async Task<IActionResult> UpdateAddress([FromBody] Addresses Offices)
        //{
        //    try
        //    {
        //        var results = await _addressesServices.UpdateAddressesAsync(Offices);
        //        return StatusCode(200, results);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Internal server error" });
        //    }
        //}

        //[HttpDelete("address/{id}")]
        //public async Task<IActionResult> DeleteAddress([FromRoute] int id)
        //{
        //    try
        //    {
        //        var results = await _addressesServices.DeteleteAddressAsync(id);
        //        return StatusCode(200, results);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = "Internal server error" });
        //    }
        //}
    }
}
