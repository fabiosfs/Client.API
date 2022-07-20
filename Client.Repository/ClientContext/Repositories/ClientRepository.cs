using clientContext = Client.Domain.ClientContext;

namespace Client.Repository.ClientContext.Repositories
{
    public class ClientRepository : clientContext.IClientRepository
    {
        public async Task<IEnumerable<clientContext.Client>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<clientContext.Client> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<clientContext.Client> InsertAsync(clientContext.Client client)
        {
            throw new NotImplementedException();
        }

        public async Task<clientContext.Client> UpdateAsync(clientContext.Client client)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
