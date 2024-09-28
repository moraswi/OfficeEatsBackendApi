using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public CategoriesRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors

        public async Task<Categories> AddCategoriesAsync(Categories categories)
        {
            await _context.Categories.AddAsync(categories);
            await _context.SaveChangesAsync();

            return categories;
        }

        public async Task<bool> DeteleteCategoryAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Categories>> GetCategoriesByStoreIdAsync(int storeId)
        {
            var categories = await _context.Categories.Where(x => x.StoreId == storeId).ToListAsync();
            return categories;
        }

        public async Task<Categories> UpdateCategoryAsync(Categories categories)
        {
            _context.Categories.Update(categories);
            await _context.SaveChangesAsync();

            return categories;
        }
    }
}
