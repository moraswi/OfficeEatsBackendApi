using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IStoreMenuRepository
    {
        Task<StoreMenu> AddStoreMenueAsync(StoreMenu storeMenu);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId);

        Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId);

        Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu);

        Task<bool> DeleteStoreMenueAsync(int id);
    }
}
