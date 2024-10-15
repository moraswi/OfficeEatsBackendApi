using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IRateRepository
    {
        Task<Rate> AddRateAsync(Rate rate);

    }
}
