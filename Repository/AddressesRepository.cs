using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Addresses>> GetAddAddressByUserIdAsync(int userId)
        {
            var addresses = await _context.Addresses.Where(x => x.UserId == userId).ToListAsync();
            return addresses;
        }
    }
}
