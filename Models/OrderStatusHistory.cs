using officeeatsbackendapi.Models;

namespace OfficeEatsBackendApi.Models
{
    public class OrderStatusHistory
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Status { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Order Order { get; set; }
    }
}
