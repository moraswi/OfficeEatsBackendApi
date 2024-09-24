using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
    }
}
