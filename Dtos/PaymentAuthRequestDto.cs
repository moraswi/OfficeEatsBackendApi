namespace OfficeEatsBackendApi.Dtos
{
    public class PaymentAuthRequestDto
    {
        public string clientId { get; set; }
        public string clientSecret { get; set; }
        public string merchantId { get; set; }
    }
}
