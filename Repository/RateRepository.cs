using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Repository
{
    public class RateRepository : IRateRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public RateRepository(DataContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        public async Task<Rate> AddRateAsync(Rate rate)
        {
            await _context.Rate.AddAsync(rate);
            await _context.SaveChangesAsync();
            return rate;
        }
    }
}
