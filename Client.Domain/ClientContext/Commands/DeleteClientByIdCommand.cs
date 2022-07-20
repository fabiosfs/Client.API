using Client.Domain.SharedContext;
using MediatR;

namespace Client.Domain.ClientContext
{
    public class DeleteClientByIdCommand : IRequest<ReturnBase>
    {
        public Guid Id { get; }
        public DeleteClientByIdCommand(Guid id) => Id = id;
    }
}
