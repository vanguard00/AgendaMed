using Agenda.Infra.Infra;
using System.Data;
using System.Data.SqlClient;

namespace Agenda.Infra.Context
{
    public class SqlServer : IDB
    {
        private SqlConnection _connection;
        private readonly IDBConfiguration _dbConfig;

        public SqlServer(IDBConfiguration dbConfig)
        {
            _dbConfig = dbConfig;
        }

        public IDbConnection connection()
        {
            return _connection = new SqlConnection(_dbConfig.ConnectionString);
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
