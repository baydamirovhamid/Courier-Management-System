using AutoMapper;

namespace billkill.manager.backend.Extensions
{
    public class MappingEntity: Profile
    {
        public MappingEntity()
        {
            //CreateMap<UpdatePersonModel, PERSONS>().ReverseMap();

            //CreateMap<INQUIRY, NewInquiryPayload>()
            //   .ForMember(dest => dest.InquiryDocType, opts => opts.MapFrom(src => src.DocTypeId))
            //   .ForMember(dest => dest.InquiryPurpose, opts => opts.MapFrom(src => src.PurposeId))
            //   .ReverseMap();
        }
    }
}
