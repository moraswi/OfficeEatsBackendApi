using AutoMapper;
using officeeatsbackendapi.Class;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Interfaces.Repository;
using officeeatsbackendapi.Interfaces.Services;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Dtos;
using OfficeEatsBackendApi.Models;

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
        #endregion Public Constructors

        public async Task<bool> ChangePasswordAsync(ChangePasswordDto changePassword)
        {
            var user = await _usersRepository.GetUserByUserIdAsync(changePassword.UserId);

            if(user == null || !VerifyPassword(changePassword.CurrentPassword, user.Password))
            {
                return false;
            }

            var results = await _usersRepository.ChangePasswordAsync(changePassword.UserId, changePassword.NewPassword);
            return results;
        }

        public Task<bool> DeleteUserAsync(int userId)
        {
            var results = _usersRepository.DeleteUserAsync(userId);
            return results;
        }

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

        //public async Task<ServiceResponse<UsersDto>> LogInAsyncOld(LogInDto logIn)
        //{
        //    var response = new ServiceResponse<UsersDto>();
        //    var result = await _usersRepository.GetUserByEmailAsync(logIn.Email);

        //    if(result == null || !VerifyPassword(logIn.Password, result.Password))
        //    {
        //        response.Success = false;
        //        response.Message = "Invalid username or password.";
        //        return response;
        //    }

        //    var userResponse = _mapper.Map<UsersDto>(result);

        //    response.Data = userResponse;
        //    response.Success = true;
        //    return response;

        //}

        public async Task<ServiceResponse<LoginResponseDto>> LogInAsync(LogInDto logIn)
        {
            var response = new ServiceResponse<LoginResponseDto>();

            // Fetch user by email
            var user = await _usersRepository.GetUserByEmailAsync(logIn.Email);

            // Validate user and password
            if (user == null || !VerifyPassword(logIn.Password, user.Password))
            {
                response.Success = false;
                response.Message = "Invalid username or password.";
                return response;
            }

            // Map user to base response
            var loginResponse = _mapper.Map<LoginResponseDto>(user);

            // Add role-specific information
            switch (user.Role.ToLower())
            {
                case "admin":
                    var storeAdmin = await _usersRepository.GetStoreAdminByUserIdAsync(user.Id);
                    if (storeAdmin != null)
                    {
                        loginResponse.StoreId = storeAdmin.StoreId;
                    }
                    break;

                case "deliverypartner":
                    var deliveryPartner = await _usersRepository.GetDeliveryPartnerByUserIdAsync(user.Id);
                    if (deliveryPartner != null)
                    {
                        loginResponse.OfficeId = deliveryPartner.OfficeId;
                    }
                    break;

                // No additional fields for "client" or other roles
                case "client":
                default:
                    break;
            }

            response.Data = loginResponse;
            response.Success = true;
            response.Message = "Login successful.";
            return response;
        }

        public async Task<ServiceResponse<UsersDto>> RegisterUserAsync(RegisterUserDto registerUser)
        {
            var response = new ServiceResponse<UsersDto>();

            var existingUserByEmail = await _usersRepository.GetUserByEmailAsync(registerUser.Email);

            if (existingUserByEmail != null) {
                response.Success = false;
                response.Message = "User with this email already exists.";
                return response;
            }

            var existingUserByPhoneNumber = await _usersRepository.GetUserByPhoneNumberAsync(registerUser.PhoneNumber);
           
            if (existingUserByPhoneNumber != null)
            {
                response.Success = false;
                response.Message = "User with this phone number already exists.";
                return response;
            }

            var newUser = _mapper.Map<Users>(registerUser);

            newUser.Password = BCrypt.Net.BCrypt.HashPassword(registerUser.Password);

            await _usersRepository.RegisterUserAsync(newUser);

            switch (registerUser.Role.ToLower())
            {
                case "admin":
                    var storeAdmin = new StoreAdmin
                    {
                        UserId = newUser.Id,
                        StoreId = (int)registerUser.StoreId // Assuming StoreId is passed in RegisterUserDto
                    };
                    await _usersRepository.RegisterStoreAdminAsync(storeAdmin);
                    break;

                case "deliverypartner":
                    var deliveryPartner = new DeliveryPartner
                    {
                        UserId = newUser.Id,
                        OfficeId = (int)registerUser.OfficeId // Assuming OfficeId is passed in RegisterUserDto
                    };
                    await _usersRepository.RegisterDeliveryPartnerAsync(deliveryPartner);
                    break;

                case "customer":
                    // No additional role registration needed for clients
                    break;

                default:
                    response.Success = false;
                    response.Message = "Invalid role specified.";
                    return response;
            }

            var userDto = _mapper.Map<UsersDto>(newUser);

            response.Data = userDto;
            response.Success = true;
            response.Message = "User registered successfully.";

            return response;

        }

        public async Task<StoreAdmin> RegisterStoreAdminAsync(StoreAdmin storeAdmin)
        {
            return await _usersRepository.RegisterStoreAdminAsync(storeAdmin);
        }

        public async Task<DeliveryPartner> RegisterDeliveryPartnerAsync(DeliveryPartner deliveryPartner)
        {
            return await _usersRepository.RegisterDeliveryPartnerAsync(deliveryPartner);
        }

        public async Task<UsersDto> UpdateUserAsync(UsersDto user)
        {
            var mapUser = _mapper.Map<Users>(user);
            var results = await _usersRepository.UpdateUserAsync(mapUser);
            var userDto = _mapper.Map<UsersDto>(results);
            return userDto;
        }

        private static bool VerifyPassword(string currentPassword, string storedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(currentPassword, storedPassword);
        }

    }
}
