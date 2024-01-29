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
            CreateMap<STATIC_DATA, StaticVM>().ReverseMap();
            CreateMap<TIME_TYPE, TimeTypeVM>().ReverseMap();
            CreateMap<STADIUM_TYPE, StadiumTypeVM>().ReverseMap();
            CreateMap<COMPANY, CompanyVM>().ReverseMap();
            CreateMap<COMPANY_BRANCH, CompanyBranch>().ReverseMap();
            CreateMap<STADIUM, StadiumDto>().ReverseMap();
            CreateMap<STADIUM_FULLIED, StadiumFulliedDto>().ReverseMap();
            CreateMap<RESERVE, ReserveDto>().ReverseMap();

            CreateMap<TIME_TYPE, TimeTypeDto>().ReverseMap();
            CreateMap<STADIUM_FULLIED, StadiumFulliedDto>().ReverseMap();
            CreateMap<STADIUM, StadiumVM>().ReverseMap();
            CreateMap<RESERVE, ReserveDto>().ReverseMap();
            CreateMap<RESERVE, ReserveVM>().ReverseMap();
            CreateMap<COMPANY_EMPLOYEE, CompanyEmployeeDto>().ReverseMap();
            CreateMap<COMPANY_EMPLOYEE, CompanyEmployeeVM>().ReverseMap();

            CreateMap<COMPANY, CompanyDto>().ReverseMap();
            CreateMap<STADIUM_FULLIED, StadiumFulliedVM>().ReverseMap();
            CreateMap<STADIUM_PRICE, StadiumPriceVM>().ReverseMap();


            CreateMap<USER, RegisterDto>().ReverseMap();
            CreateMap<USER, JwtCustomClaims>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
