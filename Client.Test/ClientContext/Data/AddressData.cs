using clientContext = Client.Domain.ClientContext;

namespace Client.Test.ClientContext
{
    public class AddressData
    {
        public static readonly string Street = "Av Cristiano Machado";
        public static readonly string ZipCode = "31234456";
        public static readonly int Number = 1234;
        public static readonly string Complement = "Bloco 1 Apto 321";
        public static readonly string Region = "Pampulha";
        public static readonly string City = "Belo Horizonte";
        public static readonly clientContext.EnState State = clientContext.EnState.MG;

        public static readonly clientContext.Address Address = new clientContext.Address()
        {
            Street = AddressData.Street,
            ZipCode = AddressData.ZipCode,
            Number = AddressData.Number,
            Complement = AddressData.Complement,
            Region = AddressData.Region,
            City = AddressData.City,
            State = AddressData.State
        };
    }
}
