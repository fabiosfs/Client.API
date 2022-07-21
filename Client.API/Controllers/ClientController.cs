using Client.Domain.ClientContext;
using Client.Domain.SharedContext;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Client.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : BaseController
    {
        private IMediator _mediator { get; }

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Listar todos clientes
        /// </summary>
        /// <response code="200">Dados processados com sucesso</response>
        /// <response code="400">Bad Request error</response>
        /// <response code="422">Parâmetros de entrada inválidos ou quebra de regras de negócio</response>
        /// <response code="500">Erro interno do Servidor</response>
        [ProducesResponseType(typeof(IEnumerable<ClientResponseDto>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(IEnumerable<string>), 422)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet]
        public async Task<ActionResult<ReturnBase>> GetAll()
        {
            var domainReturn = await _mediator.Send(new GetAllClientsCommand());
            return Return(domainReturn);
        }

        /// <summary>
        /// Buscar cliente por Id
        /// </summary>
        /// <param name="id" example="c7be9901-400d-465d-9747-d36e4489839b">Id do cliente que deseja recuperar os dados</param>
        /// <response code="200">Dados processados com sucesso</response>
        /// <response code="400">Bad Request error</response>
        /// <response code="422">Parâmetros de entrada inválidos ou quebra de regras de negócio</response>
        /// <response code="500">Erro interno do Servidor</response>
        [ProducesResponseType(typeof(ClientResponseDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(IEnumerable<string>), 422)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnBase>> Get(Guid id)
        {
            var domainReturn = await _mediator.Send(new GetClientByIdCommand(id));
            return Return(domainReturn);
        }

        /// <summary>
        /// Cadastrar novo cliente
        /// </summary>
        /// <response code="201">Cliente criado com sucesso</response>
        /// <response code="400">Bad Request error</response>
        /// <response code="422">Parâmetros de entrada inválidos ou quebra de regras de negócio</response>
        /// <response code="500">Erro interno do Servidor</response>
        [ProducesResponseType(typeof(ClientDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(IEnumerable<string>), 422)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPost]
        public async Task<ActionResult<ReturnBase>> Post([FromBody] ClientDto clientDto)
        {
            var domainReturn = await _mediator.Send(new InsertClientCommand(clientDto));
            return Return(domainReturn);
        }

        /// <summary>
        /// Atualizar cliente existente
        /// </summary>
        /// <response code="200">Cliente atualizado com sucesso</response>
        /// <response code="400">Bad Request error</response>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="422">Parâmetros de entrada inválidos ou quebra de regras de negócio</response>
        /// <response code="500">Erro interno do Servidor</response>
        [ProducesResponseType(typeof(ClientDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(IEnumerable<string>), 422)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ReturnBase>> Put(Guid id, [FromBody] ClientDto clientDto)
        {
            var domainReturn = await _mediator.Send(new UpdateClientCommand(id, clientDto));
            return Return(domainReturn);
        }

        /// <summary>
        /// Cliente excluido
        /// </summary>
        /// <response code="200">Cliente excluido com sucesso</response>
        /// <response code="400">Bad Request error</response>
        /// <response code="404">Cliente não encontrado</response>
        /// <response code="422">Parâmetros de entrada inválidos ou quebra de regras de negócio</response>
        /// <response code="500">Erro interno do Servidor</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(IEnumerable<string>), 422)]
        [ProducesResponseType(typeof(string), 500)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReturnBase>> Delete(Guid id)
        {
            var domainReturn = await _mediator.Send(new DeleteClientByIdCommand(id));
            return Return(domainReturn);
        }
    }
}