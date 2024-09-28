namespace officeeatsbackendapi.Dtos
{
    public class StoreMenuDto
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public int StoreId { get; set; }

        public decimal Price { get; set; }

        public bool Promotion { get; set; }

        public bool TopMeal { get; set; }
    }
}
