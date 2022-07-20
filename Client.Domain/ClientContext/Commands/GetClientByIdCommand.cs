using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class GetClientByIdCommand : IRequest<ReturnBase>
    {
        public Guid Id { get; }
        public GetClientByIdCommand(Guid id) => Id = id;
    }
}
