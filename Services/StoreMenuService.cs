using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class StoreMenuService : IStoreMenuService
    {
        #region Fields
        private readonly IStoreMenuRepository _storeMenuRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public StoreMenuService(IStoreMenuRepository storeMenuRepository, IMapper mapper)
        {
            _storeMenuRepository = storeMenuRepository;
            _mapper = mapper;
        }
        #endregion Public Constructors

        public async Task<StoreMenu> AddStoreMenueAsync(StoreMenuDto storeMenu)
        {
            var storeMenuEntity = _mapper.Map<StoreMenu>(storeMenu);
            var results = await _storeMenuRepository.AddStoreMenueAsync(storeMenuEntity);
            
            return results;
        }

        public async Task<bool> DeleteStoreMenueAsync(int id)
        {
            await _storeMenuRepository.DeleteStoreMenueAsync(id);
            return true;
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId)
        {
            var storeMenu = await _storeMenuRepository.GetStoreMenueByCategoryIdAsync(categoryId);
            return storeMenu;
        }

        public async Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu)
        {
           var results = await _storeMenuRepository.UpdateStoreMenuAsync(storeMenu);
            return results;
        }
    }
}
