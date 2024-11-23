using officeeatsbackendapi.Models;
using System.Threading.Tasks;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IOfficesRepository
    {
        Task<Offices> AddOfficeAsync(Offices offices);
        Task<IEnumerable<Offices>> GetAllOfficesAsync();
    }
}
