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

        public UnitOfWorkMock GetAllRepositoryMock(
            Mock<ICarRepository> carRepository,
            Mock<ICarDriverRepository> carDriverRepository,
            Mock<IDriverSalaryRepository> driverSalaryRepository,
            Mock<ITransportationRepository> transportationRepository)
        {
            Setup(x => x.CarRepository)
                .Returns(carRepository.Object);
            Setup(x => x.CarDriverRepository)
                .Returns(carDriverRepository.Object);
            Setup(x => x.DriverSalaryRepository)
                .Returns(driverSalaryRepository.Object);
            Setup(x => x.TransportationRepository)
                .Returns(transportationRepository.Object);

            return this;
        }

        //public static Mock<IUnitOfWork> GetUnitOfWorkMock(){}
    }
}