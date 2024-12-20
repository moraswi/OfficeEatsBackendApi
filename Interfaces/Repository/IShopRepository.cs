﻿using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IShopRepository
    {
        Task<Shops> AddShopAsync(Shops shops);

        Task<IEnumerable<Shops>> GetShopByOfficeIdAsync(int officeId);

    }
}
