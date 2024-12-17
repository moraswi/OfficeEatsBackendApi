using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IShopRepository
    {
        Task<Shops> AddShopAsync(Shops shops);

        Task<StoreImages> AddShopImageAsync(StoreImages image);

        Task<StoreImages> GetShopImageAsync(int storeId);

        Task<IEnumerable<Shops>> GetShopByOfficeIdAsync(int officeId);

    }
}
