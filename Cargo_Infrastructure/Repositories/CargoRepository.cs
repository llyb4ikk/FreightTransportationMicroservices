using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cargo_Domain.Entities;
using Cargo_Infrastructure.Interfaces;
using Cargo_Infrastructure.Interfaces.IRepositories;
using Cargo_Infrastructure.Models;
using Dapper;

namespace Cargo_Infrastructure.Repositories
{
    public class CargoRepository : GenericRepository<Cargo>, ICargoRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CargoRepository(IConnectionFactory connectionFactory) : base(connectionFactory, "Cargos")
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Cargo>> GetByTransprtationId(int id)
        {
            var sql = $"SELECT * FROM Cargos WHERE TransportationId = {id}";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<Cargo>(sql,
                    commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<CargoInformationModel>> GetCargosByTransportationId(int transportationId)
        {
            var sql = $"SELECT cg.Id, cg.Name, Weight, cl.Name as OwnerName, Surname as OwnerSurname, MiddleName as OwnerMiddleName " +
                           $"FROM Cargos cg " +
                           $"INNER JOIN Users cl on cl.Id = cg.OwnerId " +
                           $"WHERE cg.TransportationId = {transportationId}";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<CargoInformationModel>(sql,
                    commandType: CommandType.Text);
            }
        }

        public async Task<IEnumerable<CargoInformationModel>> GetAllCagosInformation()
        {
            var sql =
                $"SELECT cg.Id, cg.Name, Weight, cl.Name as OwnerName, Surname as OwnerSurname, MiddleName as OwnerMiddleName " +
                $"FROM Cargos cg " +
                $"INNER JOIN Users cl on cl.Id = cg.OwnerId ";

            using (var db = _connectionFactory.GetSqlConnection)
            {
                return await db.QueryAsync<CargoInformationModel>(sql,
                    commandType: CommandType.Text);
            }
        }
    }
}