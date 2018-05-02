using MongoDB.Bson;

namespace CSharp_MongoDB
{
    class Usuarios
    {
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }

        public override string ToString()
        {
            return $"Usuario: {Login} | Status: {(Ativo ? "Ativo" : "Inativo")}";
        }
    }
}
