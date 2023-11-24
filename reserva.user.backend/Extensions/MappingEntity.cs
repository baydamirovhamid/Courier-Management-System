using AutoMapper;
using reserva.user.backend.DTO.HelperModels.Jwt;
using reserva.user.backend.DTO.RequestModels;
using reserva.user.backend.DTO.RequestModels.Auth;
using reserva.user.backend.DTO.ResponseModels.Inner;
using reserva.user.backend.Models;

namespace reserva.user.backend.Extensions
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
<<<<<<< HEAD
            CreateMap<STADIUM_FULLIED, StadiumFulliedDto>().ReverseMap();

=======
            CreateMap<RESERVE, ReserveDto>().ReverseMap();
>>>>>>> c2a53f674fa15cf088409d3e38a4fed0966e4a60

            CreateMap<USER, RegisterDto>().ReverseMap();
            CreateMap<USER, JwtCustomClaims>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ReverseMap();

        }
    }
}
