using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IUsersService
    {
        Task<ServiceResponse<UsersDto>> RegisterUserAsync(RegisterUserDto registerUser);

        Task<StoreAdmin> RegisterStoreAdminAsync(StoreAdmin storeAdmin);

        Task<DeliveryPartner> RegisterDeliveryPartnerAsync(DeliveryPartner deliveryPartner);

        Task<IEnumerable<UsersDto>> GetAllUsersAsync();

        Task<UsersDto> GetUserByUserIdAsync(int userId);

        Task<UsersDto> GetUserByEmailAsync(string email);

        Task<UsersDto> GetUserByPhoneNumberAsync(string phoneNumber);

        Task<ServiceResponse<LoginResponseDto>> LogInAsync(LogInDto logIn);

        Task<UsersDto> UpdateUserAsync(UsersDto user);

        Task<bool> ChangePasswordAsync(ChangePasswordDto changePassword);

        Task<bool> DeleteUserAsync(int userId);

    }
}
