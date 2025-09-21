using AutoMapper;
using LeadsAPI.Dtos;
using LeadsAPI.Models;

namespace LeadsAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Lead, LeadListDto>();
            CreateMap<Lead, AcceptedLeadDto>()
                .ForMember(dest => dest.ContactFullName, opt => opt.MapFrom(src => $"{src.ContactFirstName} {src.ContactLastName}"));
            CreateMap<LeadsAPI.Dtos.LeadCreateDto, Lead>();
        }
    }
}
