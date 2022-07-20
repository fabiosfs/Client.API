using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class InsertClientCommand : IRequest<ReturnBase>
    {
        public ClientBaseDto ClientDto { get; }
        public InsertClientCommand(ClientBaseDto clientDto) => ClientDto = clientDto;
    }
}
