using ApplicationDemo.Data.Models;
using ApplicationDemo.Mvc.Models;
using AutoMapper;

namespace ApplicationDemo.Mvc.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactViewModel>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest =>
                dest.EmailAddress,
                opt => opt.MapFrom(src => src.EmailAddress));

            CreateMap<ContactViewModel, Contact>()
            .ForMember(dest =>
                dest.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(dest =>
                dest.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(dest =>
                dest.EmailAddress,
                opt => opt.MapFrom(src => src.EmailAddress));
        }
    }
}
