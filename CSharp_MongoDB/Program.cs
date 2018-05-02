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

                #region Adionar Registro
                //var usuario = new List<Usuarios>
                //{
                //    new Usuarios
                //    {
                //      Login = "thiago3",
                //      Senha = "1234567",
                //      Ativo = true
                //    },
                //    new Usuarios
                //    {
                //      Login = "thiago4",
                //      Senha = "1234568",
                //      Ativo = true

                //    }
                //};

                //colecao.InsertMany(usuario);
                //Console.WriteLine("Dados Inseridos com Sucesso.");
                #endregion

                #region Atualizar Registro
                //var filtro = Builders<Usuarios>.Filter.Eq(u => u.Login, "thiago2");
                //var alteracao = Builders<Usuarios>.Update.Set(u => u.Senha, "qwer@1234");
                //colecao.UpdateOne(filtro, alteracao);
                //Console.WriteLine("Registo Alterado com Sucesso!!");

                //var filtro = Builders<Usuarios>.Filter.Empty;
                //var alteracao = Builders<Usuarios>.Update.Set(u => u.Ativo, false);
                //colecao.UpdateMany(filtro, alteracao);
                //Console.WriteLine("Registro alterado com Sucesso !!");


                #endregion

                #region Excluir Registro
                //var filtro = Builders<Usuarios>.Filter.Eq(u => u.Login, "thiago2");
                //var resultado = colecao.DeleteOne(filtro);
                //Console.WriteLine($"{resultado.DeletedCount} documento(s) excluido(s).");
                #endregion

                #region Lista Registro
                //Listar Todos Resgistros
                //var filtro = Builders<Usuarios>.Filter.Empty;
                
                //Listar Somente os registros com Status Ativo
                //var filtro = Builders<Usuarios>.Filter.Where(u => u.Ativo==true);
                
                //Retorna um Registro Apenas
                var filtro = Builders<Usuarios>.Filter.Where(u => u.Login == "thiago2");

                var usuarios = colecao.Find(filtro).ToList();
                usuarios.ForEach(u => Console.WriteLine(u));
                Console.WriteLine($"Total de Registros {usuarios.Count}");
                #endregion

                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.Message}");
                Console.ReadKey();
            }
        }
    }
}
