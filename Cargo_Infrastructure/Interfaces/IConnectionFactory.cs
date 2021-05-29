using System.Data;

namespace Cargo_Infrastructure.Interfaces
{
    public interface IConnectionFactory
    {
        public IDbConnection GetSqlConnection { get; }
        public void SetConnection(string connectionString);
    }
}