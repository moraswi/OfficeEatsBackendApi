using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IShopServices
    {
        Task<ShopsDto> AddShopAsync(ShopsDto shops);
    }
}
