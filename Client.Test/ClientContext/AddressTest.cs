using Xunit;
using clientContext = Client.Domain.ClientContext;

namespace Client.Test.ClientContext
{
    public class AddressTest
    {
        [Fact]
        public void RetornSucesso()
        {
            var client = AddressData.Address;

            Assert.True(client.IsValid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressStreet(string street)
        {
            var address = new clientContext.Address(
                street,
                AddressData.ZipCode,
                AddressData.Number,
                AddressData.Complement,
                AddressData.Region,
                AddressData.City,
                AddressData.State
            );

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("123456789")]
        public void RetornErrorAddressZipCode(string zipCode)
        {
            var address = new clientContext.Address(
                AddressData.Street,
                zipCode,
                AddressData.Number,
                AddressData.Complement,
                AddressData.Region,
                AddressData.City,
                AddressData.State
            );

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        public void RetornErrorAddressNumber(int number)
        {
            if (int.MaxValue == number)
                number += 1;

            var address = new clientContext.Address(
                AddressData.Street,
                AddressData.ZipCode,
                number,
                AddressData.Complement,
                AddressData.Region,
                AddressData.City,
                AddressData.State
            );

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressComplement(string complement)
        {
            var address = new clientContext.Address(
                AddressData.Street,
                AddressData.ZipCode,
                AddressData.Number,
                complement,
                AddressData.Region,
                AddressData.City,
                AddressData.State
            );

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressRegion(string region)
        {
            var address = new clientContext.Address(
                AddressData.Street,
                AddressData.ZipCode,
                AddressData.Number,
                AddressData.Complement,
                region,
                AddressData.City,
                AddressData.State
            );

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressCity(string city)
        {
            var address = new clientContext.Address(
                AddressData.Street,
                AddressData.ZipCode,
                AddressData.Number,
                AddressData.Complement,
                AddressData.Region,
                city,
                AddressData.State
            );

            Assert.True(address.IsInvalid());
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(27)]
        public void RetornErrorAddressState(int state)
        {
            var address = new clientContext.Address(
                AddressData.Street,
                AddressData.ZipCode,
                AddressData.Number,
                AddressData.Complement,
                AddressData.Region,
                AddressData.City,
                (clientContext.EnState)state
            );

            Assert.True(address.IsInvalid());
        }
    }
}