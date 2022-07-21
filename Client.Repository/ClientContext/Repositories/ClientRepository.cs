using clientContext = Client.Domain.ClientContext;

namespace Client.Repository.ClientContext
{
    public class ClientRepository : clientContext.IClientRepository
    {
        private clientContext.Client _client { get; set; }
        public ClientRepository()
        {
            var address = new clientContext.Address()
            {
                Street = "", 
                ZipCode = "", 
                Number = 123, 
                Complement = "", 
                Region = "", 
                City = "", 
                State = clientContext.EnState.MG
            };
            _client = new clientContext.Client()
            {
                Name = "Fabio",
                BirthDate = DateTime.Now,
                Cpf = "12345678901",
                Rg = "MG12345",
                Address = address,
                Active = true
            };

        }

        public async Task<IEnumerable<clientContext.Client>> GetAllAsync()
        {
            var address = new clientContext.Address()
            {
                Street = "",
                ZipCode = null,
                Number = 123,
                Complement = "",
                Region = "",
                City = "",
                State = clientContext.EnState.MG
            };
            var client = new clientContext.Client()
            {
                Name = "Fabio",
                BirthDate = DateTime.Now,
                Cpf = null,
                Rg = "MG12345",
                Address = address,
                Active = true
            };
            return await Task.Run(() => new List<clientContext.Client>() { _client, client });
        }

        public async Task<clientContext.Client> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _client);
        }

        public async Task<clientContext.Client> InsertAsync(clientContext.Client client)
        {
            return await Task.Run(() => _client);
        }

        public async Task<clientContext.Client> UpdateAsync(clientContext.Client client)
        {
            return await Task.Run(() => _client);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Task.Run(() => _client);
        }
    }
}
