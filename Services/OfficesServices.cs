using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class OfficesServices : IOfficesServices
    {
        #region Fields
        private readonly IOfficesRepository _officesRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public OfficesServices(IOfficesRepository officesRepository, IMapper mapper)
        {
            _officesRepository = officesRepository;
            _mapper = mapper;
        }
        #endregion Public Constructors

        public async Task<OfficesDto> AddOfficeAsync(OfficesDto offices)
        {
            var officeEntity = _mapper.Map<Offices>(offices);
             await _officesRepository.AddOfficeAsync(officeEntity);
            return _mapper.Map<OfficesDto>(officeEntity);
        }

        public async Task<IEnumerable<Offices>> GetAllOfficesAsync()
        {
           var office = await _officesRepository.GetAllOfficesAsync();
            return office;
        }

    }
}
