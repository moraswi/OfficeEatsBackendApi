namespace officeeatsbackendapi.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int FoodId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderId { get; set; }

        public string FoodName { get; set; }
        

        //public Order Order { get; set; }
    }
}