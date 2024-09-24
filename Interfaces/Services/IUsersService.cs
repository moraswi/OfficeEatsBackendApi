using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();

    }
}
