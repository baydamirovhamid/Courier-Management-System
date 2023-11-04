using AutoMapper;
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

        }
    }
}
