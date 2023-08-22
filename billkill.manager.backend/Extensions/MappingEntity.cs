using AutoMapper;
using billkill.manager.backend.DTO.RequestModels;
using billkill.manager.backend.Models;

namespace billkill.manager.backend.Extensions
{
    public class MappingEntity: Profile
    {
        public MappingEntity()
        {
            CreateMap<RegisterUserDto, USER>().ReverseMap();
            CreateMap<RegisterEmployeeDto, USER>().ReverseMap();
            CreateMap<RegisterEmployeeDto, EMPLOYEE>().ReverseMap();
            CreateMap<InvoiceTypeDto, INVOICE_TYPE>().ReverseMap();

            //CreateMap<INQUIRY, NewInquiryPayload>()
            //   .ForMember(dest => dest.InquiryDocType, opts => opts.MapFrom(src => src.DocTypeId))
            //   .ForMember(dest => dest.InquiryPurpose, opts => opts.MapFrom(src => src.PurposeId))
            //   .ReverseMap();
        }
    }
}
