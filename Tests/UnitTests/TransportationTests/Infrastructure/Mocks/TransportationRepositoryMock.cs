using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;
using Moq;

namespace TransportationTests.Infrastructure.Mocks
{
    public class TransportationRepositoryMock : Mock<ITransportationRepository>
    {
        public async Task<TransportationRepositoryMock> MockGetAll(IEnumerable<Transportation> result)
        {
            Setup(x => x.GetAllAsync())
                .ReturnsAsync(result);

            return this;
        }

        public async Task<TransportationRepositoryMock> GetByIdMock(Transportation result)
        {
            Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public async Task<TransportationRepositoryMock> UpdateMock(Transportation result)
        {
            Setup(x => x.UpdateAsync(result))
                .ReturnsAsync(result);

            return this;
        }
        public async Task<TransportationRepositoryMock> AddMock(Transportation result)
        {
            Setup(x => x.AddAsync(result))
                .ReturnsAsync(result);

            return this;
        }

        //public async Task<TransportationRepositoryMock> SetupForAll();

        public static Transportation GetOne(int id = 1)
        {
            return new Transportation
            {
                Id = id,
                CarId = 1,
                Distance = 1000,
                Cost = 20000
            };
        }

        public static IEnumerable<Transportation> GetMany()
        {
            yield return GetOne();
        }
    }
}