using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using System.Threading.Tasks;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface ICategoriesService
    {
        Task<Categories> AddCategoriesAsync(CategoriesDto categoriesDto);

        Task<IEnumerable<Categories>> GetCategoriesByStoreIdAsync(int storeId);

        Task<Categories> UpdateCategoryAsync(Categories categories);

        Task<bool> DeteleteCategoryAsync(int id);
    }
}
