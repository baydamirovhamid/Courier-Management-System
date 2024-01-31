using AutoMapper;
using courier.management.system.DTO.HelperModels.Jwt;
using courier.management.system.DTO.RequestModels;
using courier.management.system.DTO.RequestModels.Auth;
using courier.management.system.DTO.ResponseModels.Inner;
using courier.management.system.Models;

namespace courier.management.system.Extensions
{
    public class MappingEntity: Profile
    {
        public MappingEntity()
        {
            CreateMap<PAYMENT, PaymentVM>().ReverseMap();
            CreateMap<COURIER, CourierVM>().ReverseMap();
            CreateMap<PACKAGE, PackageVM>().ReverseMap();

            CreateMap<PACKAGE, PackageDto>().ReverseMap();
            CreateMap<COURIER, CourierDto>().ReverseMap();
            CreateMap<PAYMENT, PaymentDto>().ReverseMap();

           
            CreateMap<USER, RegisterDto>().ReverseMap();
            CreateMap<USER, JwtCustomClaims>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
