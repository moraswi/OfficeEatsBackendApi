namespace OfficeEatsBackendApi.Dtos
{
    public class LoginResponseDto
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Role { get; set; }

        public int? StoreId { get; set; } // Only for admin role

        public int? OfficeId { get; set; } // Only for deliverypartner role
    }
}
