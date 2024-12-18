using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IShopServices
    {
        Task<Stores> AddShopAsync(ShopsDto shops);

        Task<StoreImages> AddShopImageAsync(StoreImages image);

        Task<StoreImages> GetShopImageAsync(int storeId);

        Task<IEnumerable<Stores>> GetShopByOfficeIdAsync(int officeId);

    }
}
