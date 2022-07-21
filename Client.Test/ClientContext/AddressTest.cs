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
            client.Validation();

            Assert.True(client.IsValid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressStreet(string street)
        {
            var address = new clientContext.Address()
            {
                Street = street,
                ZipCode = AddressData.ZipCode,
                Number = AddressData.Number,
                Complement = AddressData.Complement,
                Region = AddressData.Region,
                City = AddressData.City,
                State = AddressData.State
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("1234567")]
        [InlineData("123456789")]
        public void RetornErrorAddressZipCode(string zipCode)
        {
            var address = new clientContext.Address()
            {
                Street = AddressData.Street,
                ZipCode = zipCode,
                Number = AddressData.Number,
                Complement = AddressData.Complement,
                Region = AddressData.Region,
                City = AddressData.City,
                State = AddressData.State
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(int.MaxValue)]
        public void RetornErrorAddressNumber(int number)
        {
            if (int.MaxValue == number)
                number += 1;

            var address = new clientContext.Address()
            {
                Street = AddressData.Street,
                ZipCode = AddressData.ZipCode,
                Number = number,
                Complement = AddressData.Complement,
                Region = AddressData.Region,
                City = AddressData.City,
                State = AddressData.State
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressComplement(string complement)
        {
            var address = new clientContext.Address()
            {
                Street = AddressData.Street,
                ZipCode = AddressData.ZipCode,
                Number = AddressData.Number,
                Complement = complement,
                Region = AddressData.Region,
                City = AddressData.City,
                State = AddressData.State
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressRegion(string region)
        {
            var address = new clientContext.Address()
            {
                Street = AddressData.Street,
                ZipCode = AddressData.ZipCode,
                Number = AddressData.Number,
                Complement = AddressData.Complement,
                Region = region,
                City = AddressData.City,
                State = AddressData.State
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }

        [Theory]
        [InlineData("")]
        [InlineData("FabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioFabioF")]
        public void RetornErrorAddressCity(string city)
        {
            var address = new clientContext.Address()
            {
                Street = AddressData.Street,
                ZipCode = AddressData.ZipCode,
                Number = AddressData.Number,
                Complement = AddressData.Complement,
                Region = AddressData.Region,
                City = city,
                State = AddressData.State
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }


        [Theory]
        [InlineData(-1)]
        [InlineData(27)]
        public void RetornErrorAddressState(int state)
        {
            var address = new clientContext.Address()
            {
                Street = AddressData.Street,
                ZipCode = AddressData.ZipCode,
                Number = AddressData.Number,
                Complement = AddressData.Complement,
                Region = AddressData.Region,
                City = AddressData.City,
                State = (clientContext.EnState)state
            };
            address.Validation();

            Assert.True(address.IsInvalid());
        }
    }
}