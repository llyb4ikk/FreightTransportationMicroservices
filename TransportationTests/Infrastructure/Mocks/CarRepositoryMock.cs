using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces.IRepositories;
using Moq;

namespace TransportationTests.Infrastructure.Mocks
{
    public class CarRepositoryMock : Mock<ICarRepository>
    {
        public async Task<CarRepositoryMock> MockGetAll(IEnumerable<Car> result)
        {
            Setup(x => x.GetAllAsync())
                .ReturnsAsync(result);

            return this;
        }

        public async Task<CarRepositoryMock> GetByIdMock(Car result)
        {
            Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }
    }
}