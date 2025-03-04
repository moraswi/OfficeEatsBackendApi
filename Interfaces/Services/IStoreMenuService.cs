﻿using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IStoreMenuService
    {
        Task<StoreMenu> AddStoreMenueAsync(StoreMenuDto storeMenu);

        Task<StoreMenuImages> AddStoreMenuImagesAsync(StoreMenuImages image);

        Task<QuestionnaireOptions> AddQuestionnaireOptionsAsync(QuestionnaireOptions options);

        Task<QuestionnaireTitles> AddQuestionnaireTitlesAsync(QuestionnaireTitles titles);

        Task<OrderCustomizations> AddOrderCustomizationsAsync(OrderCustomizations customization);

        Task<IEnumerable<OrderCustomizations>> getOrderCustomizationsByItemIdAsync(int itemId);

        Task<IEnumerable<object>> getQuestionnaireTitlesAsync(int storeMenuId);

        Task<StoreMenuImages> GetStoreMenuImagesAsync(int storeMenuId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId);

        Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId);

        Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId);

        Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu);

        Task<bool> DeleteStoreMenueAsync(int id);
    }
}
