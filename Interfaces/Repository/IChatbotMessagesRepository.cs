using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Interfaces.Repository
{
    public interface IChatbotMessagesRepository
    {
        Task<ChatbotMessages> AddMessageAsync(ChatbotMessages chatbotMessages);
        Task<IEnumerable<ChatbotMessages>> GetMessagesAsync(int orderId);
    }
}
