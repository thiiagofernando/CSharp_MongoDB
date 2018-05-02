using System;
using System.Collections.Generic;
using MongoDB.Driver;

namespace CSharp_MongoDB
{
    class Program
    {
        //Lista de Cliente para ser inserida no banco
        static List<Cliente> GerarClientes()
        {
            var clientes = new List<Cliente>();
            clientes.Add(new Cliente
            {
                Nome = "João da Silva",
                Email = "joao@silva.com",
                Telefone = "9999-8888",
                Endereco = new Endereco
                {
                    Logradouro = "Rua Fulano de Tal",
                    Numero = 123,
                    Bairro = "Bairro Sem Nome",
                    Cidade = "Rio de Janeiro",
                    UF = "RJ"
                }
            });
            clientes.Add(new Cliente
            {
                Nome = "Pedro Rodrigues",
                Email = "joel@rodrigues.com",
                Telefone = "8888-7777",
                Endereco = new Endereco
                {
                    Logradouro = "Avenida Doutor Fulano",
                    Numero = 789,
                    Bairro = "Bairro Qualquer",
                    Cidade = "Rio de Janeiro",
                    UF = "RJ"
                }
            });
            clientes.Add(new Cliente
            {
                Nome = "Maria Aparecida",
                Email = "maria@aparecida.com",
                Telefone = "8989-7676",
                Endereco = new Endereco
                {
                    Logradouro = "Rua Sem Nome",
                    Numero = 456,
                    Bairro = "Bairro da Aparecida",
                    Cidade = "São Paulo",
                    UF = "SP"
                }
            });
            return clientes;
        }
        static void Main(string[] args)
        {

            try
            {
                //string de conexao com o servidor
                var settings = new MongoClientSettings
                {
                    ServerSelectionTimeout = new TimeSpan(0, 0, 5),
                    Server = new MongoServerAddress("localhost", 27017),
                    Credentials = new[]
                    {
                        MongoCredential.CreateCredential("loja","thiago","qwer@1234")
                    }
                };
                //Abrindo conexao com o servidor
                var client = new MongoClient(settings);
                Console.WriteLine("Conectado com Sucesso no servidor");
                Console.WriteLine();

                //Seleciono Qual Banco vou usar
                var database = client.GetDatabase("loja");
                
                //Selecion Qual Tabela vou Utilizar
                //var colecao = database.GetCollection<Usuarios>("usuarios");
                var colecao = database.GetCollection<Cliente>("clientes");


                #region Adicionar Usuario
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

                #region Atualizar Usuario
                //var filtro = Builders<Usuarios>.Filter.Eq(u => u.Login, "thiago2");
                //var alteracao = Builders<Usuarios>.Update.Set(u => u.Senha, "qwer@1234");
                //colecao.UpdateOne(filtro, alteracao);
                //Console.WriteLine("Registo Alterado com Sucesso!!");

                //var filtro = Builders<Usuarios>.Filter.Empty;
                //var alteracao = Builders<Usuarios>.Update.Set(u => u.Ativo, false);
                //colecao.UpdateMany(filtro, alteracao);
                //Console.WriteLine("Registro alterado com Sucesso !!");


                #endregion

                #region Excluir Usuarios
                //var filtro = Builders<Usuarios>.Filter.Eq(u => u.Login, "thiago2");
                //var resultado = colecao.DeleteOne(filtro);
                //Console.WriteLine($"{resultado.DeletedCount} documento(s) excluido(s).");
                #endregion

                #region Lista Usuario
                //Listar Todos Resgistros
                //var filtro = Builders<Usuarios>.Filter.Empty;

                //Listar Somente os registros com Status Ativo
                //var filtro = Builders<Usuarios>.Filter.Where(u => u.Ativo==true);

                //Retorna um Registro Apenas
                //var filtro = Builders<Usuarios>.Filter.Where(u => u.Login == "thiago2");

                //var usuarios = colecao.Find(filtro).ToList();
                //usuarios.ForEach(u => Console.WriteLine(u));
                //Console.WriteLine($"Total de Registros {usuarios.Count}");
                #endregion

                #region Inserindo Cliente
                var clientes = GerarClientes();
                colecao.InsertMany(clientes);
                Console.WriteLine("Clientes Cadastrados com Sucesso!!");
                Console.WriteLine($"Total: {clientes.Count}");
                #endregion

                #region Consultando Cliente
                //var filtro = Builders<Cliente>.Filter.Eq(c => c.Endereco.UF, "RJ");
                //var clientes = colecao.Find(filtro).ToList();
                //clientes.ForEach(c => Console.WriteLine(c));
                //Console.WriteLine($"Total: {clientes.Count}");
                #endregion

                Console.ReadKey();

            }
            catch (TimeoutException e)
            {
                Console.WriteLine($"Erro Não foi possivel realizar conexão com o servidor : {e.Message}");
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
