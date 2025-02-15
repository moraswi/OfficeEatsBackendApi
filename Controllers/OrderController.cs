using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using officeeatsbackendapi.Services;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Controllers
{
    [Route("api/")]
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


        //[HttpPost("place-order")]
        //public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        //{
        //    var response = await _orderServices.PlaceOrderAsync(orderDto);
        //    if (response.Success)
        //        return Ok(response);

        //    return BadRequest(response);
        //}

        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            if (orderDto == null)
            {
                return BadRequest("Order data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _orderServices.PlaceOrderAsync(orderDto);

            if (response == null || !response.Success)
            {
                return BadRequest(new { message = "Order placement failed.", details = response?.Message });
            }

            return Ok(response);
        }

        [HttpPost("status")]
        public async Task<IActionResult> AddOrderStatusAsync([FromBody] OrderStatusHistory status)
        {
            if (status == null)
            {
                return BadRequest("Invalid order status data.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _orderServices.AddOrderStatusAsync(status);

            if (response == null)
            {
                return StatusCode(500, "An unexpected error occurred while processing the request.");
            }

            return StatusCode(200, response);
        }

        [HttpGet("order/store/{storeid}")]
        public async Task<IActionResult> GetAllOrdersByStoreId([FromRoute] int storeid) 
        {
            if (storeid <= 0)
            {
                return BadRequest("Invalid store ID.");
            }

            var response = await _orderServices.GetAllOrdersByStoreIdAsync(storeid);

            if (response == null || !response.Any())
            {
                return NotFound("No orders found for the given store.");
            }

            return StatusCode(200, response);
        }

        [HttpGet("order-items/{orderid}")]
        public async Task<IActionResult> GetOrderItemsByOrderIdAsync([FromRoute] int orderid)
        {
            if (orderid <= 0)
            {
                return BadRequest("Invalid order ID.");
            }

            var response = await _orderServices.GetOrderItemsByOrderIdAsync(orderid);

            if (response == null || !response.Any())
            {
                return NotFound("No order items found.");
            }
            return StatusCode(200, response);
        }

        [HttpGet("order/{orderid}")]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int orderid)
        {
            if (orderid <= 0)
            {
                return BadRequest("Invalid order ID.");
            }

            var response = await _orderServices.GetOrderByIdAsync(orderid);

            if (response == null)
            {
                return NotFound("Order not found.");
            }
            return StatusCode(200, response);
        }

        [HttpGet("order/user/{userid}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] int userid)
        {
            if (userid <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            var response = await _orderServices.GetOrdersByUserIdAsync(userid);

            if (response == null || !response.Any())
            {
                return NotFound("No orders found for this user.");
            }
            return StatusCode(200, response);
        }

        [HttpGet("all-order/delivery-partner/{officeid}")]
        public async Task<IActionResult> GetDeliveryPatnerOfficePendingOrder([FromRoute] int officeid)
        {

            if (officeid <= 0)
            {
                return BadRequest("Invalid office ID.");
            }

            var response = await _orderServices.GetDeliveryPatnerOfficePendingOrderAsync(officeid);

            if (response == null || !response.Any())
            {
                return NotFound("No pending orders found for this office.");
            }
            return StatusCode(200, response);
        }

        [HttpGet("order/delivery-partner/{deliveryPartnerId}")]
        public async Task<IActionResult> GetDeliveryPatnerOrderAsync([FromRoute] int deliveryPartnerId)
        {

            if (deliveryPartnerId <= 0)
            {
                return BadRequest("Invalid delivery partner ID.");
            }

            var response = await _orderServices.GetDeliveryPatnerOrderAsync(deliveryPartnerId);

            if (response == null || !response.Any())
            {
                return NotFound("No orders found for this delivery partner.");
            }

            return StatusCode(200, response);
        }

        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto updateOrderDto)
        {
            if (updateOrderDto == null)
            {
                return BadRequest("Order data is required.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var results = await _orderServices.UpdateOrderAsync(updateOrderDto);

                if (results == null)
                {
                    return NotFound("Order not found or could not be updated.");

                }
                return StatusCode(200, results);
        }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
