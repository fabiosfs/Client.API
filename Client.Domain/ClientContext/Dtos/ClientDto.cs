namespace Client.Domain.ClientContext
{
    public class ClientDto
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public AddressDto Endereco { get; set; }
        public bool Ativo { get; set; }
    }
}
