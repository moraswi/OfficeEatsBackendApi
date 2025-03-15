using OfficeEatsBackendApi.Interfaces.Repository;
using OfficeEatsBackendApi.Interfaces.Services;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Services
{
    public class ChatbotMessagesSevices : IChatbotMessagesSevices
    {
        private readonly IChatbotMessagesRepository _chatbotMessages;

        public ChatbotMessagesSevices(IChatbotMessagesRepository chatbotMessages)
        {
            _chatbotMessages = chatbotMessages;
        }

        public async Task<ChatbotMessages> AddMessageAsync(ChatbotMessages chatbotMessages)
        {
           return await _chatbotMessages.AddMessageAsync(chatbotMessages);
        }

        public async Task<IEnumerable<ChatbotMessages>> GetMessagesAsync(int orderId)
        {
            return await _chatbotMessages.GetMessagesAsync(orderId);
        }
    }
}
