using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;


namespace officeeatsbackendapi.Helpers
{   
    public class MappingProfile : Profile
    {
        public MappingProfile() {
          
            CreateMap<Users, UsersDto>();
            CreateMap<RegisterUserDto, Users>();

            CreateMap<LogInDto, Users>();
            CreateMap<ChangePasswordDto, Users>();
        }
    }
}
