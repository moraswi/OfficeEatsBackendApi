using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using OfficeEatsBackendApi.Interfaces.Repository;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Repository
{
    public class ChatbotMessagesRepository : IChatbotMessagesRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public ChatbotMessagesRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors

        public async Task<ChatbotMessages> AddMessageAsync(ChatbotMessages chatbotMessages)
        {
            await _context.ChatbotMessages.AddAsync(chatbotMessages);
            await _context.SaveChangesAsync();
            return chatbotMessages;
        }

        public async Task<IEnumerable<ChatbotMessages>> GetMessagesAsync(int orderId)
        {
            return await _context.ChatbotMessages
                                 .Where(x => x.OrderId == orderId).ToListAsync();
        }


    }
}
