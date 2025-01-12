using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

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


        public async Task<QuestionnaireOptions> AddQuestionnaireOptionsAsync(QuestionnaireOptions options)
        {
            return await _storeMenuRepository.AddQuestionnaireOptionsAsync(options);
        }

        public async Task<QuestionnaireTitles> AddQuestionnaireTitlesAsync(QuestionnaireTitles titles)
        {
            return await _storeMenuRepository.AddQuestionnaireTitlesAsync(titles);
        }

        public async Task<StoreMenuImages> AddStoreMenuImagesAsync(StoreMenuImages image)
        {
            return await _storeMenuRepository.AddStoreMenuImagesAsync(image);
        }

        public async Task<bool> DeleteStoreMenueAsync(int id)
        {
            await _storeMenuRepository.DeleteStoreMenueAsync(id);
            return true;
        }

        public async Task<IEnumerable<QuestionnaireTitles>> getQuestionnaireTitlesAsync(int storeMenuId)
        {
            return await _storeMenuRepository.getQuestionnaireTitlesAsync(storeMenuId);
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId)
        {
            var storeMenu = await _storeMenuRepository.GetStoreMenueByCategoryIdAsync(categoryId);
            return storeMenu;
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId)
        {
            return await _storeMenuRepository.GetStoreMenueByStoreIdAsync(storeId);
        }

        public async Task<StoreMenuImages> GetStoreMenuImagesAsync(int storeMenuId)
        {
            return await _storeMenuRepository.GetStoreMenuImagesAsync(storeMenuId);
        }

        public async Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId)
        {
            var promotion = await _storeMenuRepository.GetStorePromotionMenueByStoreIdAsync(storeId);
            return promotion;
        }

        public async Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu)
        {
           var results = await _storeMenuRepository.UpdateStoreMenuAsync(storeMenu);
            return results;
        }
    }
}
