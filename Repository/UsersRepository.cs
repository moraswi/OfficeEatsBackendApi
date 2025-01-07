using Microsoft.EntityFrameworkCore;
using officeeatsbackendapi.Data;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Repository
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


        public async Task<bool> DeleteUserAsync(int userId)
        {
            var result = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);

            if (result == null)
            {
                return false;
            }

            _context.Users.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
           var results = await _context.Users.ToListAsync();
           return results;
        }

        public async Task<Users> GetUserByEmailAsync(string email)
        {
            var results = await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
            return results;
        }

        public async Task<Users> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            var results = await _context.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
            return results;
        }

        public async Task<Users> GetUserByUserIdAsync(int userId)
        {
            var results = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            return results;
        }

        public async Task<Users> RegisterUserAsync(Users users)
        {
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return users;
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> ChangePasswordAsync(int userID, string newPassword)
        {
            var user = await GetUserByUserIdAsync(userID);
            if (user == null)
            {
                return false;
            }

            user.Password = HashPassword(newPassword);

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            return true;
        }

        private string HashPassword(string password)
        {
          
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public async Task<StoreAdmin> RegisterStoreAdminAsync(StoreAdmin storeAdmin)
        {
            await _context.StoreAdmin.AddAsync(storeAdmin);
            await _context.SaveChangesAsync();

            return storeAdmin;
        }

        public async Task<DeliveryPartner> RegisterDeliveryPartnerAsync(DeliveryPartner deliveryPartner)
        {
            await _context.DeliveryPartner.AddAsync(deliveryPartner);
            await _context.SaveChangesAsync();

            return deliveryPartner;
        }

        public async Task<StoreAdmin> GetStoreAdminByUserIdAsync(int userId)
        {
            return await _context.StoreAdmin.FirstOrDefaultAsync(sa => sa.UserId == userId);
        }

        public async Task<DeliveryPartner> GetDeliveryPartnerByUserIdAsync(int userId)
        {
            return await _context.DeliveryPartner.FirstOrDefaultAsync(dp => dp.UserId == userId);
        }
    }
}
