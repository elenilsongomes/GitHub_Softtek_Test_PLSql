using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Sqlite;
using System.Threading.Tasks;

namespace Questao5.Application.Queries.Responses
{
    public class CreateMovimentoResponse : ICreateMovimentoResponse
    {
        //public Guid id { get; set; }
        //public string idmovimento { get; set; }
        //public string idcontacorrente { get; set; }
        //public string? datamovimento { get; set; }
        //public string tipomovimento { get; set; }
        //public double valor { get; set; }

        private readonly DatabaseConfig databaseConfig;

        public CreateMovimentoResponse(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
            new DatabaseBootstrap(databaseConfig).Setup();
        }

        public async Task <IEnumerable<Movimento>> Get(string idcontacorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            string sql = "SELECT idmovimento, idcontacorrente, datamovimento, tipomovimento, valor " +
                         "FROM movimento WHERE idcontacorrente = @idcontacorrente;";

            return await connection.QueryAsync<Movimento>(sql, new { idcontacorrente });
        }
    }
}
