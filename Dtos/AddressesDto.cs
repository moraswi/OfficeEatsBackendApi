namespace officeeatsbackendapi.Dtos
{
    public class AddressesDto
    {
        public string OfficePack { get; set; }

        public string? OfficeAddress { get; set; }

        public int? UserId { get; set; }

        public bool Active { get; set; }

        public string? Town { get; set; }

        public string? Province { get; set; }

        public string? Apartment { get; set; }

        public string? StreetAddress { get; set; }

        public string? PostalCode { get; set; }

        public string? RecipientName { get; set; }

        public string? RecipientMobileNumber { get; set; }

        public string? Suburb { get; set; }

    }
}
