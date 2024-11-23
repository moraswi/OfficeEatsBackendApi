using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class AddressesServices : IAddressesServices
    {
        #region Fields
        private readonly IAddressesRepository _addressesRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public AddressesServices(IAddressesRepository addressesRepository, IMapper mapper)
        {
            _addressesRepository = addressesRepository;
            _mapper = mapper;
        }
        #endregion Public Constructors

        public async Task<IEnumerable<Addresses>> GetAddAddressByUserIdAsync(int userId)
        {
            var addresses = await _addressesRepository.GetAddAddressByUserIdAsync(userId);
            return addresses;
        }


        public async Task<Addresses> AddAddress(AddressesDto address)
        {
            var addressEntity = _mapper.Map<Addresses>(address);
            var results = await _addressesRepository.AddAddress(addressEntity);
            return results;
        }

        public async Task<Addresses> UpdateAddressesAsync(Addresses addresses)
        {
            await _addressesRepository.UpdateAddressesAsync(addresses);
            return addresses;
        }

        public async Task<bool> DeteleteAddressAsync(int id)
        {
            await _addressesRepository.DeteleteAddressAsync(id);
            return true;
        }
    }
}
