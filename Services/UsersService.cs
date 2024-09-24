using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;

namespace officeeatsbackendapi.Services
{
    public class UsersService : IUsersService
    {
        #region Fields
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        #endregion Fields

        #region Public Constructors
        public UsersService(IUsersRepository usersRepository, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
        }

        public Task<bool> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            var results = _usersRepository.DeleteUserAsync(userId);
            return results;
        }
        #endregion Public Constructors


        public async Task<IEnumerable<UsersDto>> GetAllUsersAsync()
        {
            var users = await _usersRepository.GetAllUsersAsync();
            if (users == null)
            {
                return new List<UsersDto>();
            }
            return _mapper.Map<IEnumerable<UsersDto>>(users);
        }

        public async Task<UsersDto> GetUserByEmailAsync(string email)
        {
            var results = await _usersRepository.GetUserByEmailAsync(email);
            var userDto = _mapper.Map<UsersDto>(results);

            return userDto;
        }

        public async Task<UsersDto> GetUserByPhoneNumberAsync(string phoneNumber)
        {
            var results = await _usersRepository.GetUserByPhoneNumberAsync(phoneNumber);
            var userDto = _mapper.Map<UsersDto>(results);

            return userDto;
        }

        public async Task<UsersDto> GetUserByUserIdAsync(int userId)
        {
            var results = await _usersRepository.GetUserByUserIdAsync(userId);
            var userDto = _mapper.Map<UsersDto>(results);

            return userDto;
        }

        public Task<LogInDto> LogInAsync(LogInDto logIn)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(RegisterUserDto registerUser)
        {
            var results = _mapper.Map<Users>(registerUser);
            results.Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            await _usersRepository.RegisterUserAsync(results);
        }

        public Task<Users> UpdateUserAsync(Users user)
        {
            throw new NotImplementedException();
        }

        private static bool VerifyPassword(string currentPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(currentPassword, storedPassword);
        }
    }
}
