using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Interfaces.Repository
{
    public interface IUsersRepository
    {
        Task<Users> RegisterUserAsync(Users users);

        Task<StoreAdmin> RegisterStoreAdminAsync(StoreAdmin storeAdmin);

        Task<DeliveryPartner> RegisterDeliveryPartnerAsync(DeliveryPartner deliveryPartner);

        Task<IEnumerable<Users>> GetAllUsersAsync();

        Task<Users> GetUserByUserIdAsync(int userId);

        Task<Users> GetUserByEmailAsync(string email);

        Task<Users> GetUserByPhoneNumberAsync(string phoneNumber);

        Task<bool> ChangePasswordAsync(int userId, string newPassword);

        Task<Users> UpdateUserAsync(Users user);

        Task<bool> DeleteUserAsync(int userId);

    }
}
