using AutoMapper;
using Client.Domain.SharedContext;
using MediatR;
using System.Net;

namespace Client.Domain.ClientContext
{
    public class ClientHandler : 
        IRequestHandler<GetAllClientsCommand, ReturnBase>,
        IRequestHandler<GetClientByIdCommand, ReturnBase>,
        IRequestHandler<InsertClientCommand, ReturnBase>,
        IRequestHandler<UpdateClientCommand, ReturnBase>,
        IRequestHandler<DeleteClientByIdCommand, ReturnBase>
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapp;
        private readonly Util _util;
        public ClientHandler(IClientRepository repository, IMapper mapp, Util util)
        {
            _repository = repository;
            _mapp = mapp;
            _util = util;
        }

        public async Task<ReturnBase> Handle(GetAllClientsCommand request, CancellationToken cancellationToken)
        {
            return await _util.TryCatch(async () =>
            {
                var clients = await _repository.GetAllAsync();
                var returned = _mapp.Map<IEnumerable<ClientResponseDto>>(clients);

                return new ReturnBase(HttpStatusCode.OK, returned);
            });
        }

        public async Task<ReturnBase> Handle(GetClientByIdCommand request, CancellationToken cancellationToken)
        {
            return await _util.TryCatch(async () =>
            {
                var client = await _repository.GetByIdAsync(request.Id);
                var returned = _mapp.Map<ClientResponseDto>(client);

                return new ReturnBase(HttpStatusCode.OK, returned);
            });
        }

        public async Task<ReturnBase> Handle(InsertClientCommand request, CancellationToken cancellationToken)
        {
            return await _util.TryCatch(async () =>
            {
                var client = _mapp.Map<Client>(request.ClientDto);
                _util.ValidationEntity(client);
                var clientInsert = await _repository.InsertAsync(client);
                var returned = _mapp.Map<ClientDto>(clientInsert);

                return new ReturnBase(HttpStatusCode.Created, returned);
            });
        }

        public async Task<ReturnBase> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            return await _util.TryCatch(async () =>
            {
                var returnClient = await _repository.GetByIdAsync(request.Id);
                if (returnClient == null)
                    throw new DataNotFoundException($"Nenhum cliente encontrado para o Id: {request.Id}");
                
                var client = _mapp.Map<Client>(request.ClientDto);
                client.ChangeId(request.Id);
                _util.ValidationEntity(client); 
                var clients = await _repository.UpdateAsync(client);
                var returned = _mapp.Map<ClientDto>(clients);

                return new ReturnBase(HttpStatusCode.OK, returned);
            });
        }

        public async Task<ReturnBase> Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
        {
            return await _util.TryCatch(async () =>
            {
                var returnClient = await _repository.GetByIdAsync(request.Id);
                if (returnClient == null)
                    throw new DataNotFoundException($"Nenhum cliente encontrado para o Id: {request.Id}");

                await _repository.DeleteAsync(request.Id);
                return new ReturnBase(HttpStatusCode.OK, null);
            });
        }
    }
}
