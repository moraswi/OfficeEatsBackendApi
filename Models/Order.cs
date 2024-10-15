namespace officeeatsbackendapi.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; }

        public decimal TotalAmount { get; set; }

        public string DeliveryAddress { get; set; }

        public string PaymentStatus { get; set; } = "Pending";

        public string DeliveryStatus { get; set; } = "Preparing";

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int ShopId { get; set; }
    }
}
