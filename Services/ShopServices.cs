using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using officeeatsbackendapi.Repository;

namespace officeeatsbackendapi.Services
{
    public class ShopServices : IShopServices
    {
        #region Fields
        private readonly IShopRepository _shopRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public ShopServices(IShopRepository shopRepository, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _mapper = mapper;
        }
        #endregion Public Constructors

        public async Task<Stores> AddShopAsync(ShopsDto shops)
        {
            var shopEntity = _mapper.Map<Stores>(shops);
            var results = await _shopRepository.AddShopAsync(shopEntity);
            return results;
        }

        public async Task<StoreImages> AddShopImageAsync(StoreImages image)
        {
            return await _shopRepository.AddShopImageAsync(image);
        }

        public async Task<IEnumerable<Stores>> GetShopByOfficeIdAsync(int officeId)
        {
            var shop = await _shopRepository.GetShopByOfficeIdAsync(officeId);
            return shop;
        }

        public async Task<StoreImages> GetShopImageAsync(int storeId)
        {
            return await _shopRepository.GetShopImageAsync(storeId);
        }
    }
}
