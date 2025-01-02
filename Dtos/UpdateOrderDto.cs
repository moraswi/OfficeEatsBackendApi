using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace OfficeEatsBackendApi.Dtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? DeliveryAddress { get; set; }

        public string? PaymentMethod { get; set; }

        public string? OrderStatus { get; set; }

        public DateTime? OrderDate { get; set; }

        public int? ShopId { get; set; }

        public string? OrderCode { get; set; }

        public string? StoreName { get; set; }

        public string? Description { get; set; }

    }
}
