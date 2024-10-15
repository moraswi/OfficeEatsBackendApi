using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class RateServices : IRateServices
    {
        #region Fields
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public RateServices(IRateRepository rateRepository, IMapper mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }

        #endregion Public Constructors


        public async Task<RateDto> AddRatingAsync(RateDto rateDto)
        {
            var rateEntity = _mapper.Map<Rate>(rateDto);
            await _rateRepository.AddRateAsync(rateEntity);
            return _mapper.Map<RateDto>(rateEntity);
        }
    }
}
