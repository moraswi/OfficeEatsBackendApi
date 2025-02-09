using OfficeEatsBackendApi.Models;

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

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public List<OrderCustomizations> OrderCustomizations { get; set; } = new List<OrderCustomizations>();


        //public Order Order { get; set; }
    }
}