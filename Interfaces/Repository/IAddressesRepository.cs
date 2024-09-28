using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IAddressesRepository
    {
        Task<Addresses> AddAddress(Addresses address);

        Task<IEnumerable<Addresses>> GetAddAddressByUserIdAsync(int userId);

        Task<Addresses> UpdateAddressesAsync(Addresses addresses);

        Task<bool> DeteleteAddressAsync(int id);
    }
}
