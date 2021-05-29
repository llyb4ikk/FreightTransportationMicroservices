using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;
using Moq;

namespace TransportationTests.Infrastructure.Mocks
{
    public class UnitOfWorkMock : Mock<IUnitOfWork>
    {
        public UnitOfWorkMock GetCarRepositoryMock(ICarRepository result)
        {
            Setup(x => x.CarRepository)
                .Returns(result);
            
            return this;
        }

        public UnitOfWorkMock VerifyGetCarRepository(Times times)
        {
            Verify(x => x.CarRepository, times);

            return this;
        }
    }
}