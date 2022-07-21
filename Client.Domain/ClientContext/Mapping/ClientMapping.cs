using AutoMapper;

namespace Client.Domain.ClientContext
{
    public class ClientMapping : Profile
    {
        public ClientMapping()
        {
            CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf))
                .ForMember(dest => dest.Rg, opt => opt.MapFrom(src => src.Rg))
                .ForMember(dest => dest.CreateDate, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.Notifications, opt => opt.Ignore());

            CreateMap<Client, ClientResponseDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.BirthDate))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Address));
        }
    }
}
