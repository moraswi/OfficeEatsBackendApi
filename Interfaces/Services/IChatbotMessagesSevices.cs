using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Interfaces.Services
{
    public interface IChatbotMessagesSevices
    {
        Task<ChatbotMessages> AddMessageAsync(ChatbotMessages chatbotMessages);
        Task<IEnumerable<ChatbotMessages>> GetMessagesAsync(int orderId);
    }
}
