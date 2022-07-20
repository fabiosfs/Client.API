namespace Client.Domain.ClientContext
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetAllAsync();
        public Task<Client> GetByIdAsync(Guid id);
        public Task<Client> InsertAsync(Client client);
        public Task<Client> UpdateAsync(Client client);
        public Task DeleteAsync(Guid id);
    }
}
