using AutoMapper;
using billkill.payment.service.DTO.HelperModels;
using billkill.payment.service.DTO.RequestModels;
using billkill.payment.service.Models;

namespace billkill.payment.service.Extensions
{
    public class MappingEntity: Profile
    {
        public MappingEntity()
        {
            CreateMap<TerminalLoginDto, UserClaims>().ReverseMap();

            //CreateMap<INQUIRY, NewInquiryPayload>()
            //   .ForMember(dest => dest.InquiryDocType, opts => opts.MapFrom(src => src.DocTypeId))
            //   .ForMember(dest => dest.InquiryPurpose, opts => opts.MapFrom(src => src.PurposeId))
            //   .ReverseMap();
        }
    }
}
