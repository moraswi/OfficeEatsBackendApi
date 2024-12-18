namespace officeeatsbackendapi.Models
{
    public class StoreMenu
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int StoreId { get; set; }

        public decimal Price { get; set; }

        public bool Promotion { get; set; }

        public bool TopMeal { get; set; }

        public string Description { get; set; }

        public StoreMenuImages StoreMenuImages { get; set; }

    }
}
