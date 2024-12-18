using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IShopRepository
    {
        Task<Stores> AddShopAsync(Stores shops);

        Task<StoreImages> AddShopImageAsync(StoreImages image);

        Task<StoreImages> GetShopImageAsync(int storeId);

        Task<IEnumerable<Stores>> GetShopByOfficeIdAsync(int officeId);

    }
}
