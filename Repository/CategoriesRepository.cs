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

        public async Task<IEnumerable<Categories>> GetCategoriesByStoreIdAsync(int storeId)
        {
            var categories = await _context.Categories.Where(x => x.StoreId == storeId).ToListAsync();
            return categories;
        }

    }
}
