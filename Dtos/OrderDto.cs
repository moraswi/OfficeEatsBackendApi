namespace officeeatsbackendapi.Dtos
{
    public class OrderDto
    {
        public int UserId { get; set; }


        public string? DeliveryAddress { get; set; }

        public string? PaymentMethod { get; set; }

        public int? ShopId { get; set; }

        public int? OfficeId { get; set; }

        public int? DeliveryPartnerId { get; set; }

        public string? StoreName { get; set; }

        public string? Description { get; set; }

        public List<OrderItemDto> Items { get; set; }

    }
}
