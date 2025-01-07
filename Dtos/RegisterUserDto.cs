namespace officeeatsbackendapi.Dtos
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; } // "client", "storeadmin", "deliverypartner"

        public int? StoreId { get; set; } // Required for admin

        public int? OfficeId { get; set; } // Required for deliverypartner

    }
}
