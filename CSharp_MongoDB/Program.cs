using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace CSharp_MongoDB
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("loja");
                var colecao = database.GetCollection<Usuarios>("usuarios");

                var usuario = new List<Usuarios>
                {
                    new Usuarios
                    {
                      Login = "thiago2",
                      Senha = "1234567"
                    },
                    new Usuarios
                    {
                      Login = "thiago2",
                      Senha = "1234568"
                    }
                };
                colecao.InsertMany(usuario);
                Console.WriteLine("Dados Inseridos com Sucesso.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
            }
        }
    }
}
