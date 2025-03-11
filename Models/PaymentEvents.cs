using System.ComponentModel.DataAnnotations;

namespace OfficeEatsBackendApi.Models
{
    public class PaymentEvents
    {
        [Key] public int IdPaymentEvents { get; set; }

        public string? Id { get; set; }
        public string? ReferencedId { get; set; }
        //public string? PaymentType { get; set; }
        //public string? PaymentBrand { get; set; }
        //public string? Amount { get; set; }
        //public string? MerchantTransactionId { get; set; }
        //public string? MerchantInvoiceId { get; set; }
        //public string? MerchantAccountId { get; set; }
        //public string? Descriptor { get; set; }
        //public string? Currency { get; set; }
        //public string? PresentationAmount { get; set; }
        //public string? PresentationCurrency { get; set; }

        //public string? Result_Code { get; set; }
        //public string? Result_Description { get; set; }

        //public string? ResultDetails_ClearingInstituteName { get; set; }
        //public string? ResultDetails_ExtendedDescription { get; set; }
        //public string? ResultDetails_AcquirerResponse { get; set; }

        //public string? ConnectorTxID1 { get; set; }
        //public string? Authentication_EntityId { get; set; }

        //public string? Card_Bin { get; set; }
        //public string? Card_Last4Digits { get; set; }
        //public string? Card_Holder { get; set; }
        //public string? Card_Type { get; set; }
        //public string? Card_ExpiryMonth { get; set; }
        //public string? Card_ExpiryYear { get; set; }

        //public string? Timestamp { get; set; }
        //public string? Customer_GivenName { get; set; }
        //public string? Customer_Surname { get; set; }
        //public string? Customer_MerchantCustomerId { get; set; }
        //public string? Customer_Sex { get; set; }
        //public string? Customer_Mobile { get; set; }
        //public string? Customer_Email { get; set; }
        //public string? Customer_Status { get; set; }
        //public string? Customer_Phone { get; set; }

        //public string? Shipping_Street1 { get; set; }
        //public string? Shipping_Street2 { get; set; }
        //public string? Shipping_City { get; set; }
        //public string? Shipping_Country { get; set; }
        //public string? Shipping_State { get; set; }
        //public string? Shipping_Postcode { get; set; }
        //public string? Shipping_Company { get; set; }

        //public string? Billing_Street1 { get; set; }
        //public string? Billing_Street2 { get; set; }
        //public string? Billing_City { get; set; }
        //public string? Billing_Sex { get; set; }
        //public string? Billing_Country { get; set; }
        //public string? Billing_State { get; set; }
        //public string? Billing_Postcode { get; set; }
        //public string? Billing_Company { get; set; }

        //public string? Shopify_OrderId { get; set; }
        //public string? Shopify_AccountId { get; set; }
        //public string? Shopify_Signature { get; set; }
        //public string? Shopify_TestMode { get; set; }

        //public string? BankAccount_Holder { get; set; }
        //public string? BankAccount_BankName { get; set; }
        //public string? BankAccount_BankCode { get; set; }

        //public string? Recon_AuthCode { get; set; }
        //public string? Recon_CiMerchantNumber { get; set; }
        //public string? Recon_ResultCode { get; set; }
        //public string? Recon_rrn { get; set; }
        //public string? Recon_Stan { get; set; }

        public string? CustomParameters_PEACH_MERCHANT_ID { get; set; }
        //public DateTime? CreatedAt { get; set; } = DateTime.Now;

        //}

    }
}
