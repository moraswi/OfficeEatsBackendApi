using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IStoreMenuService
    {
        Task<StoreMenu> AddStoreMenueAsync(StoreMenuDto storeMenu);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId);

        Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu);

        Task<bool> DeleteStoreMenueAsync(int id);
    }
}
