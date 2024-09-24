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

            CreateMap<Users, LogInDto>();
            CreateMap<ChangePasswordDto, Users>();
        }
    }
}
