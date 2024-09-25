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

        public async Task<ShopsDto> AddShopAsync(ShopsDto shops)
        {
            var shopEntity = _mapper.Map<Shops>(shops);
            var results = await _shopRepository.AddShopAsync(shopEntity);
            return _mapper.Map<ShopsDto>(shopEntity);
        }

    }
}
