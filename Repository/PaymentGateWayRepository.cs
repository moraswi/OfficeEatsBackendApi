using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Helpers;
using OfficeEatsBackendApi.Interfaces.Repository;
using OfficeEatsBackendApi.Models;

namespace OfficeEatsBackendApi.Repository
{
    public class PaymentGateWayRepository : IPaymentGateWayRepository
    {
        private DataContext _context;

        public PaymentGateWayRepository(DataContext Context)
        {
            _context = Context;


        }
        //public async Task<Payments> AddPayment(Payments request)
        //{
        //    await _context.Payments.AddAsync(request);
        //    await _context.SaveChangesAsync();

        //    return request;
        //}

        //public async Task<PaymentEvents> AddPaymentEvents(PaymentEvents request)
        //{
        //    await _context.PaymentEvents.AddAsync(request);
        //    await _context.SaveChangesAsync();
        //    return request;
        //}

        public async Task<StoreBankingDetails> GetBankingDetailsByStoreIdAsync(int storeId)
        {
            return await _context.StoreBankingDetails.FirstOrDefaultAsync(x => x.StoreId == storeId);
        }

        //public async Task<Payments> GetPaymentByTransactionIdAsync(string transactionId)
        //{
        //    return await _context.Payments.FirstOrDefaultAsync(x => x.MerchantTransactionId == transactionId);
        //}

        //public async Task<Payments> UpdatePaymentAsync(Payments request)
        //{
        //    _context.Payments.Update(request);
        //    await _context.SaveChangesAsync();
        //    return request;
        //}
    }
}
