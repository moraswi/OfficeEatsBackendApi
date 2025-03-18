namespace OfficeEatsBackendApi.Models
{
    public class StoreBankingDetails
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Reference { get; set; }
        public string AccountName { get; set; }
        public int StoreId { get; set; }

    }
}
