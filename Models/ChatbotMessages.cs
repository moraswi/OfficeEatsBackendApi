namespace OfficeEatsBackendApi.Models
{
    public class ChatbotMessages
    {
        public int Id { get; set; }

        public int StoreId { get; set; }

        public int OrderId { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
