using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Repository
{
    public class StoreMenuRepository : IStoreMenuRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public StoreMenuRepository(DataContext context)
        {
            _context = context;
        }

      
        #endregion Public Constructors

        public async Task<StoreMenu> AddStoreMenueAsync(StoreMenu storeMenu)
        {

            await _context.StoreMenu.AddAsync(storeMenu);
            await _context.SaveChangesAsync();

            return storeMenu;
        }

        public async Task<QuestionnaireOptions> AddQuestionnaireOptionsAsync(QuestionnaireOptions options)
        {
            await _context.QuestionnaireOptions.AddAsync(options);
            await _context.SaveChangesAsync();

            return options;
        }

        public async Task<QuestionnaireTitles> AddQuestionnaireTitlesAsync(QuestionnaireTitles titles)
        {
            await _context.QuestionnaireTitles.AddAsync(titles);
            await _context.SaveChangesAsync();

            return titles;
        }

        public async Task<StoreMenuImages> AddStoreMenuImagesAsync(StoreMenuImages image)
        {
            await _context.StoreMenuImages.AddAsync(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<bool> DeleteStoreMenueAsync(int id)
        {
            var storeMenu = await _context.StoreMenu.FindAsync(id);
            _context.StoreMenu.Remove(storeMenu);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<object>> getQuestionnaireTitlesAsync(int storeMenuId)
        {
            return await _context.QuestionnaireTitles
               .Where(qt => qt.StoreMenuId == storeMenuId)
               .Select(qt => new
               {
                   id = qt.Id,
                   storeMenuId = qt.StoreMenuId,
                   title = qt.Title,
                   options = _context.QuestionnaireOptions
                       .Where(qo => qo.QuestionnaireTitleId == qt.Id)
                       .Select(qo => new
                       {
                           name = qo.Name,
                           price = qo.Price
                       }).ToList()
               })
               .ToListAsync();
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByCategoryIdAsync(int categoryId)
        {
            var results = await _context.StoreMenu
                .Include(menu => menu.StoreMenuImages)
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
            return results;
        }

        public async Task<IEnumerable<StoreMenu>> GetStoreMenueByStoreIdAsync(int storeId)
        {
            var results = await _context.StoreMenu.Where(x => x.StoreId == storeId).ToListAsync();
            return results;
        }

        public async Task<StoreMenuImages> GetStoreMenuImagesAsync(int storeMenuId)
        {
            return await _context.StoreMenuImages.FindAsync(storeMenuId);
        }

        public async Task<IEnumerable<StoreMenu>> GetStorePromotionMenueByStoreIdAsync(int storeId)
        {
            var results = await _context.StoreMenu.Where(x => x.StoreId == storeId && x.Promotion == true).ToListAsync();
            return results;
        }

        public async Task<StoreMenu> UpdateStoreMenuAsync(StoreMenu storeMenu)
        {
            _context.StoreMenu.Update(storeMenu);
            await _context.SaveChangesAsync();
            return storeMenu;
        }
    }
}
