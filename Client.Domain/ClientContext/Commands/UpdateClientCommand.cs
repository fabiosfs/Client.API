using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class UpdateClientCommand : IRequest<ReturnBase>
    {
        public ClientDto ClientDto { get; }
        public UpdateClientCommand(ClientDto clientDto)
        {
            ClientDto = clientDto;
        }
    }
}
