using System.ComponentModel.DataAnnotations;

namespace OfficeEatsBackendApi.Models
{
    public class Payments
    {
        public int PaymentsId { get; set; }

        public string IdNumber { get; set; }
        public double Amount { get; set; }
        public string Status { get; set; }
        public string MerchantTransactionId { get; set; }
        public string Nonce { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
