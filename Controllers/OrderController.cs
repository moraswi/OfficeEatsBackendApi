﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using officeeatsbackendapi.Services;
using OfficeEatsBackendApi.Dtos;

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


        [HttpPost("place-order")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            var response = await _orderServices.PlaceOrderAsync(orderDto);
            if (response.Success)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpGet("order/store/{storeid}")]
        public async Task<IActionResult> GetAllOrdersByStoreId([FromRoute] int storeid) 
        {
            var response = await _orderServices.GetAllOrdersByStoreIdAsync(storeid);
            return StatusCode(200, response);
        }

        [HttpGet("order-items/{orderid}")]
        public async Task<IActionResult> GetOrderItemsByOrderIdAsync([FromRoute] int orderid)
        {
            var response = await _orderServices.GetOrderItemsByOrderIdAsync(orderid);
            return StatusCode(200, response);
        }

        [HttpGet("order/{orderid}")]
        public async Task<IActionResult> GetOrderByIdAsync([FromRoute] int orderid)
        {
            var response = await _orderServices.GetOrderByIdAsync(orderid);
            return StatusCode(200, response);
        }

        [HttpGet("order/user/{userid}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] int userid)
        {
            var response = await _orderServices.GetOrdersByUserIdAsync(userid);
            return StatusCode(200, response);
        }

        [HttpGet("all-order/delivery-partner/{officeid}")]
        public async Task<IActionResult> GetDeliveryPatnerOfficePendingOrder([FromRoute] int officeid)
        {
            var response = await _orderServices.GetDeliveryPatnerOfficePendingOrderAsync(officeid);
            return StatusCode(200, response);
        }

        [HttpGet("order/delivery-partner/{deliveryPartnerId}")]
        public async Task<IActionResult> GetDeliveryPatnerOrderAsync([FromRoute] int deliveryPartnerId)
        {
            var response = await _orderServices.GetDeliveryPatnerOrderAsync(deliveryPartnerId);
            return StatusCode(200, response);
        }

        [HttpPut("order")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto updateOrderDto)
        {
            try
            {
                var results = await _orderServices.UpdateOrderAsync(updateOrderDto);
                return StatusCode(200, results);
        }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
