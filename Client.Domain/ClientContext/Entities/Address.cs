using Client.Domain.SharedContext;
using prmToolkit.NotificationPattern;

namespace Client.Domain.ClientContext
{
    public class Address : EntityBase
    {
        public string Street { get; private set; }
        public string ZipCode { get; private set; }
        public int Number { get; private set; }
        public string Complement { get; private set; }
        public string Region { get; private set; }
        public string City { get; private set; }
        public EnState State { get; private set; }
        public Guid ClientId { get; private set; }
        public Client Client { get; private set; }

        public Address(string street, string zipCode, int number, string complement, string region, string city, EnState state)
        {
            Street = street;
            ZipCode = zipCode;
            Number = number;
            Complement = complement;
            Region = region;
            City = city;
            State = state;

            new AddNotifications<Address>(this)
                .IfNullOrInvalidLength(address => address.Street, 1, 150, "A rua deve conter de 1 a 150 caracteres.")
                .IfNullOrInvalidLength(address => address.ZipCode, 8, 8, "O CEP deve conter 8 caracteres.")
                .IfTrue(Number < 0 || Number > int.MaxValue, "", $"O número deve estar entre 0 a {int.MaxValue}.")
                .IfLengthGreaterThan(address => address.Complement, 255, "O complemento deve conter até 255 caracteres.")
                .IfNullOrInvalidLength(address => address.Region, 1, 150, "O bairro deve conter de 1 a 150 caracteres.")
                .IfNullOrInvalidLength(address => address.City, 1, 150, "A cidade deve conter de 1 a 150 caracteres.")
                .IfEnumInvalid(address => address.State, "A sigla do estado informado é invalido.");
        }

        public void AddIdClient(Guid clientId) => ClientId = clientId;
    }
}
