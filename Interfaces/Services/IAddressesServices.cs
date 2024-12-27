using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IAddressesServices
    {
        Task<Addresses> AddAddress(AddressesDto address);

        Task<Addresses> GetAddressByUserIdAsync(int userId);

        Task<Addresses> UpdateAddressesAsync(Addresses addresses);

        Task<bool> DeteleteAddressAsync(int id);

    }
}
