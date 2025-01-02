using AutoMapper;
using officeeatsbackendapi.Dtos;
using officeeatsbackendapi.Models;
using OfficeEatsBackendApi.Dtos;


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

            CreateMap<Stores, ShopsDto>();
            CreateMap<ShopsDto, Stores>();

            CreateMap<AddressesDto, Addresses>();
            CreateMap<Addresses, AddressesDto>();

            CreateMap<CategoriesDto, Categories>();
            CreateMap<Categories, CategoriesDto>();

            CreateMap<StoreMenuDto, StoreMenu>();
            CreateMap<StoreMenu, StoreMenuDto>();

            CreateMap<RateDto, Rate>();
            CreateMap<Rate, RateDto>();

            CreateMap<UpdateOrderDto, Order>();

            CreateMap<OrderItemDto, OrderItem>()
                  .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => src.Quantity * src.ItemPrice));

            CreateMap<OrderDto, Order>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.Items.Sum(i => i.Quantity * i.ItemPrice)))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));

        }
    }
}
