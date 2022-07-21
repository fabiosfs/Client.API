using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class InsertClientCommand : IRequest<ReturnBase>
    {
        public ClientDto ClientDto { get; }
        public InsertClientCommand(ClientDto clientDto) => ClientDto = clientDto;
    }
}
