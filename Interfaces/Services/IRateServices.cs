using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IRateServices
    {
        Task<RateDto> AddRatingAsync(RateDto rateDto);
    }
}
