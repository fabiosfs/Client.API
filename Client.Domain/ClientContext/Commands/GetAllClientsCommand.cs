using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class GetAllClientsCommand : IRequest<ReturnBase>
    {
    }
}
