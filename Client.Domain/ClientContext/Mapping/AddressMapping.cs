using AutoMapper;

namespace Client.Domain.ClientContext
{
    public class AddressMapping : Profile
    {
        public AddressMapping()
        {
            CreateMap<AddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Rua))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Estado))
                .ForMember(dest => dest.Client, opt => opt.Ignore())
                .ForMember(dest => dest.Notifications, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
