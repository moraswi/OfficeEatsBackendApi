using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IAddressesRepository
    {
        Task<Addresses> AddAddress(Addresses address);
        Task<IEnumerable<Addresses>> GetAddAddressByUserIdAsync(int userId);
    }
}
