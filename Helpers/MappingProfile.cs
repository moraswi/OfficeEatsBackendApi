using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;


namespace officeeatsbackendapi.Helpers
{   
    public class MappingProfile : Profile
    {
        public MappingProfile() {
          
            CreateMap<Users, UsersDto>();
            CreateMap<UsersDto, Users>();

            CreateMap<RegisterUserDto, Users>();

            CreateMap<Users, LogInDto>();
            CreateMap<ChangePasswordDto, Users>();

            CreateMap<Offices, OfficesDto>();
            CreateMap<OfficesDto, Offices>();



        }
    }
}
