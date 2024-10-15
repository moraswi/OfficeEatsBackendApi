namespace officeeatsbackendapi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string FoodItemName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }
    }
}


/*   public int Id { get; set; }

        public int UserId { get; set; }

        public List<OrderItem> Items { get; set; } 

        public decimal TotalAmount { get; set; }

        public string DeliveryAddress { get; set; }

        public string PaymentStatus { get; set; } = "Pending";

        public string DeliveryStatus { get; set; } = "Preparing"; 

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public int ShopId { get; set; }
*/