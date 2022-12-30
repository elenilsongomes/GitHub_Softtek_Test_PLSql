using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;
using System.Threading.Tasks;

namespace Questao5.Application.Commands.Requests
{
    public class CreateMovimentoRequest : ICreateMovimentoRequest
    {
        //public string idmovimento { get; set; }
        //public string idcontacorrente { get; set; }
        //public string? datamovimento { get; set; }
        //public string tipomovimento { get; set; }
        //public double valor { get; set; }

        private readonly DatabaseConfig databaseConfig;

        public CreateMovimentoRequest(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
            new DatabaseBootstrap(databaseConfig).Setup();
        }

        public async Task Create(Movimento movimento)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            string sql = "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) " +
                         "VALUES (@idmovimento, @idcontacorrente, @datamovimento, @tipomovimento, @valor);";

            await connection.ExecuteAsync(sql, movimento);
        }
    }
}
