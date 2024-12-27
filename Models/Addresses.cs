namespace officeeatsbackendapi.Models
{
    public class Addresses
    {
        public int Id { get; set; }

        public string OfficePack { get; set; }

        public string OfficeAddress { get; set; }

        public int UserId { get; set; }

        public bool Active { get; set; }

    }
}
