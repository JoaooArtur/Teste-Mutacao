using Application.Core.Entities;
using Application.Core.Repository.Interfaces;
using Dapper;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Core.Repository
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private readonly string ConectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CrudFuncionarios;Integrated Security=SSPI";

        public async Task<Funcionario> Insert(Funcionario funcionario) 
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = "INSERT INTO Funcionarios (Codigo,Nome,Documento,Idade) OUTPUT Inserted.* VALUES (NEWID(),@Nome,@Documento,@Idade);";
                var fromDB = await db.QueryAsync<Funcionario>(query, funcionario);
                return fromDB.FirstOrDefault();
            }
        }

        public async void Update(Guid codigo,Funcionario funcionario)
        {
            funcionario.Codigo = codigo;
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = "UPDATE Funcionarios SET Nome = @Nome, Documento = @Documento, Idade = @Idade WHERE Codigo = @Codigo;";
                await db.QueryAsync(query, funcionario);
            }
        }

        public async void Delete(Guid codigo)
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"DELETE FROM Funcionarios WHERE Codigo = '{codigo}'";
                var clientes = await db.ExecuteAsync(query,codigo);
            }
        }

        public async Task<Funcionario> Get(Guid codigo)
        {
            using (var db = new SqlConnection(ConectionString))
            {
                await db.OpenAsync();
                var query = $"SELECT * FROM Funcionarios WHERE Codigo = '{codigo}'";
                var fromDB = await db.QueryAsync<Funcionario>(query);
                return fromDB.FirstOrDefault();
            }
        }
    }
}
