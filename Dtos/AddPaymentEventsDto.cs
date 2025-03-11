namespace OfficeEatsBackendApi.Dtos
{

        public class AddPaymentEventsDto
        {
            public string? Id { get; set; }
            public string? ReferencedId { get; set; }
            public string? PaymentType { get; set; }
            public string? PaymentBrand { get; set; }
            public string? Amount { get; set; }
            public string? MerchantTransactionId { get; set; }
            public string? MerchantInvoiceId { get; set; }
            public string? MerchantAccountId { get; set; }
            public string? Descriptor { get; set; }
            public string? Currency { get; set; }
            public string? PresentationAmount { get; set; }
            public string? PresentationCurrency { get; set; }
            public ResultDto? Result { get; set; }
            public ResultDetailsDto? ResultDetails { get; set; }
            public string? ConnectorTxID1 { get; set; }
            public AuthenticationDto? Authentication { get; set; }
            public CardDto? Card { get; set; }
            public string? Timestamp { get; set; }
            public CustomerDto? Customer { get; set; }
            public ShippingDto? Shipping { get; set; }
            public BillingDto? Billing { get; set; }
            public ShopifyDto? Shopify { get; set; }
            public BankAccountDto? BankAccount { get; set; }
            public ReconDto? Recon { get; set; }
            public CustomParametersDto? CustomParameters { get; set; }
        }

        public class ResultDto
        {
            public string Code { get; set; }
            public string Description { get; set; }
        }

        public class ResultDetailsDto
        {
            public string ClearingInstituteName { get; set; }
            public string ExtendedDescription { get; set; }
            public string AcquirerResponse { get; set; }
        }

        public class AuthenticationDto
        {
            public string EntityId { get; set; }
        }

        public class CardDto
        {
            public string Bin { get; set; }
            public string Last4Digits { get; set; }
            public string Holder { get; set; }
            public string Type { get; set; }
            public string ExpiryMonth { get; set; }
            public string ExpiryYear { get; set; }
        }

        public class CustomerDto
        {
            public string GivenName { get; set; }
            public string Surname { get; set; }
            public string MerchantCustomerId { get; set; }
            public string Sex { get; set; }
            public string Mobile { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
            public string Phone { get; set; }
        }

        public class ShippingDto
        {
            public string Street1 { get; set; }
            public string Street2 { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
            public string Company { get; set; }
        }

        public class BillingDto
        {
            public string Street1 { get; set; }
            public string Street2 { get; set; }
            public string City { get; set; }
            public string Sex { get; set; }
            public string Country { get; set; }
            public string State { get; set; }
            public string Postcode { get; set; }
            public string Company { get; set; }
        }

        public class ShopifyDto
        {
            public string OrderId { get; set; }
            public string AccountId { get; set; }
            public string Signature { get; set; }
            public string TestMode { get; set; }
        }

        public class BankAccountDto
        {
            public string Holder { get; set; }
            public string BankName { get; set; }
            public string BankCode { get; set; }
        }

        public class ReconDto
        {
            public string AuthCode { get; set; }
            public string CiMerchantNumber { get; set; }
            public string ResultCode { get; set; }
            public string Rrn { get; set; }
            public string Stan { get; set; }
        }

        public class CustomParametersDto
        {
            public string PEACH_MERCHANT_ID { get; set; }
        }
  
}
