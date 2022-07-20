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
            Assert.True(client.IsValid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorClientName(string name)
        {
            var client = new clientContext.Client(
                name,
                ClientData.BirthDate,
                ClientData.Cpf,
                ClientData.Rg,
                ClientData.Address,
                ClientData.CreateDate,
                ClientData.Active
            );

            Assert.True(client.IsInvalid());
        }

        [Theory]
        [InlineData("1752-12-31")]
        [InlineData("")]
        public void RetornErrorClientBirthDate(string birthDate)
        {
            if (string.IsNullOrEmpty(birthDate))
                birthDate = DateTime.Now.AddDays(1).ToString();

            var client = new clientContext.Client(
                ClientData.Name,
                Convert.ToDateTime(birthDate),
                ClientData.Cpf,
                ClientData.Rg,
                ClientData.Address,
                ClientData.CreateDate,
                ClientData.Active
            );

            Assert.True(client.IsInvalid());
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("123456789012")]
        public void RetornErrorClientCpf(string cpf)
        {
            var client = new clientContext.Client(
                ClientData.Name,
                ClientData.BirthDate,
                cpf,
                ClientData.Rg,
                ClientData.Address,
                ClientData.CreateDate,
                ClientData.Active
            );

            Assert.True(client.IsInvalid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("12345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901")]
        public void RetornErrorClientRg(string rg)
        {
            var client = new clientContext.Client(
                ClientData.Name,
                ClientData.BirthDate,
                ClientData.Cpf,
                rg,
                ClientData.Address,
                ClientData.CreateDate,
                ClientData.Active
            );

            Assert.True(client.IsInvalid());
        }

        [Fact]
        public void RetornErrorAddressNull()
        {
            var client = new clientContext.Client(
                ClientData.Name,
                ClientData.BirthDate,
                ClientData.Cpf,
                ClientData.Rg,
                null,
                ClientData.CreateDate,
                ClientData.Active
            );

            Assert.True(client.IsInvalid());
        }

    }
}