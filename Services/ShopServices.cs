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

        public async Task<Shops> AddShopAsync(ShopsDto shops)
        {
            var shopEntity = _mapper.Map<Shops>(shops);
            var results = await _shopRepository.AddShopAsync(shopEntity);
            return results;
        }

        public async Task<IEnumerable<Shops>> GetShopByOfficeIdAsync(int officeId)
        {
            var shop = await _shopRepository.GetShopByOfficeIdAsync(officeId);
            return shop;
        }
    }
}
