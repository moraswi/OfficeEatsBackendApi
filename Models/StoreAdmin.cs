namespace OfficeEatsBackendApi.Models
{
    public class StoreAdmin
    {
        public int Id { get; set; }

        public String? FirstName { get; set; }
        public String? LastName { get; set; }
        public String? Email { get; set; }
        public String? Password { get; set; }

        public int? UserId { get; set; }
        public int? StoreId { get; set; }

    }
}
