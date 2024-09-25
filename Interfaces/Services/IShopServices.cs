using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IShopServices
    {
        Task<Shops> AddShopAsync(ShopsDto shops);

        Task<IEnumerable<Shops>> GetShopByOfficeIdAsync(int officeId);

    }
}
