using System.Text.Json.Serialization;

namespace Client.Domain.ClientContext
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public string? Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnState Estado { get; set; }
    }
}
