using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Dtos
{
    public class OrderDto
    {
        public int UserId { get; set; }


        public string? DeliveryAddress { get; set; }

        public string? PaymentMethod { get; set; }

        public int? ShopId { get; set; }

        public int? OfficeId { get; set; }

        public decimal? DeliveryFee { get; set; }

        public int? DeliveryPartnerId { get; set; }

        public string? StoreName { get; set; }

        public string? Description { get; set; }

        public List<OrderItemDto> Items { get; set; }
        public List<OrderStatusHistoryDto> OrderStatusHistory { get; set; } = new List<OrderStatusHistoryDto>();

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
