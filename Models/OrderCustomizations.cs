namespace OfficeEatsBackendApi.Models
{
    public class OrderCustomizations
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int TitleId { get; set; }
        public string OptionName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        
    }
}
