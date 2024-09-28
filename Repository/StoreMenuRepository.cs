using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Repository
{
    public class StoreMenuRepository : IStoreMenuRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public StoreMenuRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors

        public async Task<StoreMenu> AddStoreMenueAsync(StoreMenu storeMenu)
        {

            await _context.StoreMenu.AddAsync(storeMenu);
            await _context.SaveChangesAsync();

            return storeMenu;
        }

        public async Task<bool> DeleteStoreMenueAsync(int id)
        {
            var storeMenu = await _context.StoreMenu.FindAsync(id);
            _context.StoreMenu.Remove(storeMenu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId)
        {
            var results = await _context.StoreMenu.Where(x => x.CategoryId == categoryId).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId)
        {
            var results = await _context.StoreMenu.Where(x => x.StoreId == storeId && x.TopMeal == true).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId)
        {
            var results = await _context.StoreMenu.Where(x => x.StoreId == storeId && x.Promotion == true).ToListAsync();
            return results;
        }

        public async Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu)
        {
            _context.StoreMenu.Update(storeMenu);
            await _context.SaveChangesAsync();
            return storeMenu;
        }
    }
}
