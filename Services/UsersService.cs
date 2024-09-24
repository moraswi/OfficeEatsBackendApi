using AutoMapper;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class UsersService : IUsersService
    {
        #region Fields
        private readonly IUsersRepository _usersRepository;
        #endregion Fields

        #region Public Constructors
        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        #endregion Public Constructors


        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }
    }
}
