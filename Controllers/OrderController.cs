using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Services;

namespace officeeatsbackendapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region Fields
        private readonly IOrderServices _orderServices;
        #endregion Fields

        #region Public Constructors
        public OrderController(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }
        #endregion Public Constructors


        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            var response = await _orderServices.PlaceOrderAsync(orderDto);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("order-bystoreid/{storeid}")]
        public async Task<IActionResult> GetAllOrdersByStoreId([FromRoute] int storeid) 
        {
            var response = await _orderServices.GetAllOrdersByStoreIdAsync(storeid);
            return StatusCode(200, response);
        }
    }
}
