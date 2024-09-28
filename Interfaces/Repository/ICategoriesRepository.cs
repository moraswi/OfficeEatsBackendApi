using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface ICategoriesRepository
    {
        Task<Categories> AddCategoriesAsync(Categories categories);

        Task<IEnumerable<Categories>> GetCategoriesByStoreIdAsync(int storeId);

        Task<Categories> UpdateCategoryAsync(Categories categories);

        Task<bool> DeteleteCategoryAsync(int id);
    }
}
