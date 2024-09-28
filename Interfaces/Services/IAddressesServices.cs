using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IAddressesServices
    {
        Task<Addresses> AddAddress(AddressesDto address);
        Task<IEnumerable<Addresses>> GetAddAddressByUserIdAsync(int userId);

    }
}
