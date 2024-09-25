using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Repository
{
    public class ShopRepository : IShopRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public ShopRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors


        public async Task<Shops> AddShopAsync(Shops shops)
        {
            await _context.Shops.AddAsync(shops);
            _context.SaveChangesAsync();
            return shops;
        }

    }
}
