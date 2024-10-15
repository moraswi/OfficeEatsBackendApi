namespace officeeatsbackendapi.Dtos
{
    public class OrderDto
    {
        public int UserId { get; set; }

        public List<OrderItemDto> Items { get; set; }

        public string DeliveryAddress { get; set; }

        public int ShopId { get; set; }

    }
}
