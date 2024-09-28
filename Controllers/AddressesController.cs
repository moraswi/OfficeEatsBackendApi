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
    public class AddressesController : ControllerBase
    {
        #region Fields
        private readonly IAddressesServices _addressesServices;
        #endregion Fields

        #region Public Constructors
        public AddressesController(IAddressesServices addressesServices)
        {
            _addressesServices = addressesServices;
        }
        #endregion Public Constructors

        [HttpPost("address")]
        public async Task<IActionResult> AddAddress([FromBody] AddressesDto addresses)
        {
            try
            {
                var results = await _addressesServices.AddAddress(addresses);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("addresses/{userid}")]
        public async Task<IActionResult> GetAllAddresses([FromRoute] int userid)
        {
            try
            {
                var results = await _addressesServices.GetAddAddressByUserIdAsync(userid);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpPut("address")]
        public async Task<IActionResult> UpdateAddress([FromBody] Addresses addresses)
        {
            try
            {
                var results = await _addressesServices.UpdateAddressesAsync(addresses);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpDelete("address/{id}")]
        public async Task<IActionResult> DeleteAddress([FromRoute] int id)
        {
            try
            {
                var results = await _addressesServices.DeteleteAddressAsync(id);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

    }
}
