namespace officeeatsbackendapi.Dtos
{
    public class OrderItemDto
    {
        //public int FoodItemId { get; set; }
        public int FoodId { get; set; }

        public int Quantity { get; set; }

        public double ItemPrice { get; set; }

        public string FoodName { get; set; }


    }
}
