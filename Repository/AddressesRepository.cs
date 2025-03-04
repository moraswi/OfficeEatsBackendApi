﻿using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Repository
{
    public class AddressesRepository : IAddressesRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public AddressesRepository(DataContext context)
        {
            _context = context;
        }

        #endregion Public Constructors

        public async Task<Addresses> AddAddress(Addresses address)
        {
            await _context.Addresses.AddAsync(address);
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeteleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);

             _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Addresses> GetAddressByUserIdAsync(int userId)
        {
            var addresses = await _context.Addresses.FirstOrDefaultAsync(x => x.UserId == userId);
            return addresses;
        }

        public async Task<Addresses> UpdateAddressesAsync(Addresses addresses)
        {
            _context.Addresses.Update(addresses);
            await _context.SaveChangesAsync();

            return addresses;
        }
    }
}
