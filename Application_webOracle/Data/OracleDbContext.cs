using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Application_webOracle.Data
{
	public class OracleDbContext
	{
		private readonly string _connectionString;

        public OracleDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("OracleDbConnection");
        }

        public OracleConnection CreateConnection()
        {
            return new OracleConnection(_connectionString);
        }

    }
}
