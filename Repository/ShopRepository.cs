﻿using Microsoft.EntityFrameworkCore;
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


        public async Task<Stores> AddShopAsync(Stores shops)
        {
            await _context.Stores.AddAsync(shops);
            await _context.SaveChangesAsync();
            return shops;
        }

        public async Task<StoreImages> AddShopImageAsync(StoreImages image)
        {
            await _context.StoreImages.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<IEnumerable<Stores>> GetShopByOfficeIdAsync(int officeId)
        {
            var shop = await _context.Stores.Include(x => x.StoreImages) .Where(x => x.OfficeId == officeId).ToListAsync();
            //var shop = await _context.Stores.Where(x => x.OfficeId == officeId).ToListAsync();
            return shop;
        }

        public async Task<StoreImages> GetShopImageAsync(int storeId)
        {
            return await _context.StoreImages.FirstOrDefaultAsync(x => x.StoresId == storeId);
        }
    }
}
