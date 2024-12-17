using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IStoreMenuService
    {
        Task<StoreMenu> AddStoreMenueAsync(StoreMenuDto storeMenu);

        Task<StoreMenuImages> AddStoreMenuImagesAsync(StoreMenuImages image);

        Task<StoreMenuImages> GetStoreMenuImagesAsync(int storeMenuId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId);

        Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId);

        Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu);

        Task<bool> DeleteStoreMenueAsync(int id);
    }
}
