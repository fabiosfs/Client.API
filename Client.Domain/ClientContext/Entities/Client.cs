using Client.Domain.SharedContext;
using prmToolkit.NotificationPattern;

namespace Client.Domain.ClientContext
{
    public class Client : EntityBase
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public Address Address { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }

        public override void Validation()
        {
            new AddNotifications<Client>(this)
                .IfNullOrInvalidLength(client => client.Name, 1, 255, "O nome do cliente deve conter de 1 a 255 caracteres.")
                .IfFalse(BirthDate > new DateTime(1753, 1, 1), "", "A data de nascimento do cliente deve ser maior que 01/01/1753.")
                .IfFalse(BirthDate.Date <= DateTime.Now.Date, "", "A data de nascimento do client deve ser menor que a data atual.")
                .IfNullOrInvalidLength(client => client.Cpf, 11, 11, "O CPF do cliente deve conter 11 caracteres.")
                .IfNullOrInvalidLength(client => client.Rg, 1, 100, "O RG do cliente deve conter no máximo 100 caracteres.");

            if (Address == null)
                AddNotification("", "É obrigatório informar um endereço para o cliente.");
            else
            {
                Address.Validation();
                AddNotifications(Address);
            }
        }
    }
}
