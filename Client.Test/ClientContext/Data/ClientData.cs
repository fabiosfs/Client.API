using clientContext = Client.Domain.ClientContext;

namespace Client.Test.ClientContext
{
    public class ClientData
    {
        public static readonly string Name = "Fábio Dos Santos";
        public static readonly DateTime BirthDate = new DateTime(1999, 3, 9);
        public static readonly string Cpf = "12345678901";
        public static readonly string Rg = "MG1234567890";
        public static readonly clientContext.Address Address = AddressData.Address;
        public static readonly DateTime CreateDate = DateTime.Now;
        public static readonly bool Active = true;

        public static readonly clientContext.Client Client = new clientContext.Client()
        {
            Name = ClientData.Name,
            BirthDate = ClientData.BirthDate,
            Cpf = ClientData.Cpf,
            Rg = ClientData.Rg,
            Address = ClientData.Address,
            CreateDate = ClientData.CreateDate,
            Active = ClientData.Active
        };
    }
}
