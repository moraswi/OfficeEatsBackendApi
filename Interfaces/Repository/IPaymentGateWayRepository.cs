using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Interfaces.Repository
{
    public interface IPaymentGateWayRepository
    {
        //Task<Payments> AddPayment(Payments request);
        //Task<PaymentEvents> AddPaymentEvents(PaymentEvents request);
        //Task<Payments> UpdatePaymentAsync(Payments request);
        //Task<Payments> GetPaymentByTransactionIdAsync(string transactionId);
        Task<StoreBankingDetails> GetBankingDetailsByStoreIdAsync(int storeId);

    }
}
