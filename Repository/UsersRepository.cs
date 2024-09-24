using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;

namespace pepbackendapi.Repository
{
    public class UsersRepository : IUsersRepository
    {
        #region Fields
        private readonly DataContext _context;
        #endregion Fields


        #region Public Constructors
        public UsersRepository(DataContext context)
        {
            _context = context;
        }
        #endregion Public Constructors


        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
           return await _context.Users.ToListAsync();
        }
    }
}
