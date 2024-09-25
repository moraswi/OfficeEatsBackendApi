using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IOfficesServices
    {
        Task<OfficesDto> AddOfficeAsync(OfficesDto offices);
        Task<IEnumerable<OfficesDto>> GetAllOfficesAsync();
    }
}
