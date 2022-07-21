using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class UpdateClientCommand : IRequest<ReturnBase>
    {
        public Guid Id { get; }
        public ClientDto ClientDto { get; }
        public UpdateClientCommand(Guid id, ClientDto clientDto)
        {
            Id = id;
            ClientDto = clientDto;
        }
    }
}
