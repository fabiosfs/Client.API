using Client.Domain.SharedContext;
using prmToolkit.NotificationPattern;

namespace Client.Domain.ClientContext
{
    public class Client : EntityBase
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Cpf { get; private set; }
        public string Rg { get; private set; }
        public Address Address { get; private set; }
        public DateTime CreateDate { get; private set; }
        public bool Active { get; private set; }

        public Client(string name, DateTime birthDate, string cpf, string rg, Address address, DateTime createDate, bool active)
        {
            Name = name;
            BirthDate = birthDate;
            Cpf = cpf;
            Rg = rg;
            Address = address;
            CreateDate = createDate;
            Active = active;

            new AddNotifications<Client>(this)
                .IfNullOrInvalidLength(client => client.Name, 1, 255, "O nome do cliente deve conter de 1 a 255 caracteres.")
                .IfFalse(BirthDate > new DateTime(1753, 1, 1), "", "A data de nascimento do cliente deve ser maior que 01/01/1753.")
                .IfFalse(BirthDate < DateTime.Now, "", "A data de nascimento do client deve ser menor que a data atual.")
                .IfNullOrInvalidLength(client => client.Cpf, 11, 11, "O CPF do cliente deve conter 11 caracteres.")
                .IfNullOrInvalidLength(client => client.Rg, 1, 100, "O RG do cliente deve conter no máximo 100 caracteres.");

            if (Address == null)
                AddNotification("", "É obrigatório informar um endereço para o cliente.");
            else
                AddNotifications(Address);
        }
    }
}
