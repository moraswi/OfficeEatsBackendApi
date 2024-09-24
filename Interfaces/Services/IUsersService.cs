using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Interfaces.Services
{
    public interface IUsersService
    {
        Task RegisterUserAsync(RegisterUserDto registerUser);

        Task<IEnumerable<UsersDto>> GetAllUsersAsync();

        Task<UsersDto> GetUserByUserIdAsync(int userId);

        Task<UsersDto> GetUserByEmailAsync(string email);

        Task<UsersDto> GetUserByPhoneNumberAsync(string phoneNumber);

        Task<ServiceResponse<UsersDto>> LogInAsync(LogInDto logIn);

        Task<Users> UpdateUserAsync(Users user);

        Task<bool> ChangePasswordAsync(ChangePasswordDto changePassword);

        Task<bool> DeleteUserAsync(int userId);

    }
}
