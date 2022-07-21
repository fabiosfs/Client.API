using Xunit;
using clientContext = Client.Domain.ClientContext;

namespace Client.Test.ClientContext
{
    public class ClientTest
    {
        [Fact]
        public void RetornSucesso()
        {
            var client = ClientData.Client;
            client.Validation();

            Assert.True(client.IsValid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorClientName(string name)
        {
            var client = new clientContext.Client()
            {
                Name = name,
                BirthDate = ClientData.BirthDate,
                Cpf = ClientData.Cpf,
                Rg = ClientData.Rg,
                Address = ClientData.Address
            };
            client.Validation();

            Assert.True(client.IsInvalid());
        }

        [Theory]
        [InlineData("1752-12-31")]
        [InlineData("")]
        public void RetornErrorClientBirthDate(string birthDate)
        {
            if (string.IsNullOrEmpty(birthDate))
                birthDate = DateTime.Now.AddDays(1).ToString();

            var client = new clientContext.Client()
            {
                Name = ClientData.Name,
                BirthDate = Convert.ToDateTime(birthDate),
                Cpf = ClientData.Cpf,
                Rg = ClientData.Rg,
                Address = ClientData.Address
            };
            client.Validation();

            Assert.True(client.IsInvalid());
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("123456789012")]
        public void RetornErrorClientCpf(string cpf)
        {
            var client = new clientContext.Client()
            {
                Name = ClientData.Name,
                BirthDate = ClientData.BirthDate,
                Cpf = cpf,
                Rg = ClientData.Rg,
                Address = ClientData.Address
            };
            client.Validation();

            Assert.True(client.IsInvalid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901")]
        public void RetornErrorClientRg(string rg)
        {
            var client = new clientContext.Client()
            {
                Name = ClientData.Name,
                BirthDate = ClientData.BirthDate,
                Cpf = ClientData.Cpf,
                Rg = rg,
                Address = ClientData.Address
            };
            client.Validation();

            Assert.True(client.IsInvalid());
        }

        [Fact]
        public void RetornErrorAddressNull()
        {
            var client = new clientContext.Client()
            {
                Name = ClientData.Name,
                BirthDate = ClientData.BirthDate,
                Cpf = ClientData.Cpf,
                Rg = ClientData.Rg,
                Active = ClientData.Active
            };
            client.Validation();

            Assert.True(client.IsInvalid());
        }
    }
}