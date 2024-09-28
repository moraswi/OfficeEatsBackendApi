using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class CategoriesService : ICategoriesService
    {
        #region Fields
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        #endregion Public Constructors

        public async Task<Categories> AddCategoriesAsync(CategoriesDto categoriesDto)
        {
            var categoryEntity = _mapper.Map<Categories>(categoriesDto);
            var results = await _categoriesRepository.AddCategoriesAsync(categoryEntity);

            return results;
        }

        public async Task<IEnumerable<Categories>> GetCategoriesByStoreIdAsync(int storeId)
        {
            var results = await _categoriesRepository.GetCategoriesByStoreIdAsync(storeId);
            return results;
        }

    }
}
