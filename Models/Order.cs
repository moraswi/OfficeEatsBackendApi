using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public decimal? TotalAmount { get; set; }

        public decimal? DeliveryFee { get; set; }

        public string? DeliveryAddress { get; set; }

        public string? PaymentMethod { get; set; }

        public string? OrderStatus { get; set; } = "Pending";

        public DateTime? OrderDate { get; set; }

        public int? OfficeId { get; set; }

        public int? DeliveryPartnerId { get; set; }

        public int? ShopId { get; set; }

        public string? OrderCode { get; set; }

        public string? StoreName { get; set; }

        public string? Description { get; set; }
        
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public List<OrderStatusHistory> OrderStatusHistory { get; set; } = new List<OrderStatusHistory>();

        public string? Town { get; set; }

        public string? Province { get; set; }

        public string? Apartment { get; set; }

        public string? StreetAddress { get; set; }

        public string? PostalCode { get; set; }

        public string? RecipientName { get; set; }

        public string? RecipientMobileNumber { get; set; }

        public string? Suburb { get; set; }
    }
}
