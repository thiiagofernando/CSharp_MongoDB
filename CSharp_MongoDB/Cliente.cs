using MongoDB.Bson;

namespace CSharp_MongoDB
{
    class Cliente
    {
        public ObjectId _id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"{Nome}{System.Environment.NewLine}{Endereco.Logradouro},{Endereco.Numero}.{Endereco.Bairro}.{Endereco.Cidade}-{Endereco.UF}{System.Environment.NewLine}";
        }
    }
}
