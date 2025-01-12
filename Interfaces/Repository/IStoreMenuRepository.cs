using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IStoreMenuRepository
    {
        Task<StoreMenu> AddStoreMenueAsync(StoreMenu storeMenu);

        Task<StoreMenuImages> AddStoreMenuImagesAsync(StoreMenuImages image);
        Task<QuestionnaireOptions> AddQuestionnaireOptionsAsync(QuestionnaireOptions options);

        Task<QuestionnaireTitles> AddQuestionnaireTitlesAsync(QuestionnaireTitles titles);

        Task<IEnumerable<QuestionnaireTitles>> getQuestionnaireTitlesAsync(int storeMenuId);

        Task<StoreMenuImages> GetStoreMenuImagesAsync(int storeMenuId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId);

        Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId);

        Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu);

        Task<bool> DeleteStoreMenueAsync(int id);
    }
}
