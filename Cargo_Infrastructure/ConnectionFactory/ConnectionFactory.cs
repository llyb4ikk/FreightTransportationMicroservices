using System.Data;
using System.Data.SqlClient;
using Cargo_Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Cargo_Infrastructure.ConnectionFactory
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration configuation;
        private static string _connectionString;

        public ConnectionFactory(IConfiguration Configuation)
        {
            configuation = Configuation;
        }
        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetSqlConnection
        {
            get
            {
                SqlConnection connection;
                if (!string.IsNullOrEmpty(_connectionString))
                    connection = new SqlConnection(_connectionString);
                else
                    connection = new SqlConnection(configuation.GetValue<string>("ConnectionStrings:DefaultConnection"));
                connection.Open();
                return connection;
            }
        }
    }
}