using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Services;
using OfficeEatsBackendApi.Interfaces.Services;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ChatbotMessagesController : ControllerBase
    {

        #region Fields
        private readonly IChatbotMessagesSevices _chatbotMessagesSevices;
        #endregion Fields

        #region Public Constructors
        public ChatbotMessagesController(IChatbotMessagesSevices chatbotMessagesSevices)
        {
            _chatbotMessagesSevices = chatbotMessagesSevices;
        }
        #endregion Public Constructors


        [HttpPost("message")]
        public async Task<IActionResult> AddMessage([FromBody] ChatbotMessages chatbotMessages)
        {
            try
            {
                var results = await _chatbotMessagesSevices.AddMessageAsync(chatbotMessages);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }

        [HttpGet("message/{orderId}")]
        public async Task<IActionResult> GetMessages([FromRoute] int orderId)
        {
            try
            {
                var results = await _chatbotMessagesSevices.GetMessagesAsync(orderId);
                return StatusCode(200, results);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error" });
            }
        }
    }
}
