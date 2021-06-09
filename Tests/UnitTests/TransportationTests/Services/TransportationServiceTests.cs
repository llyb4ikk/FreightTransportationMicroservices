using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport.Mapping;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Interfaces.IServices;
using FreightTransport_BLL.Services;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Enums;
using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;
using Moq;
using TransportationTests.Infrastructure.Mocks;
using Xunit;

namespace TransportationTests.Services
{
    public class TransportationServiceTests
    {
        private readonly IMapper _mapper;

        public TransportationServiceTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MainMappingProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }


        [Fact]
        public async Task GetSalary_ReturnsSalary()
        {
            // Arrange
            var expected = 2700;

            var carDriverMock = new Mock<ICarDriverService>();
            var driverSalaryMock = new Mock<IDriverSalaryService>();
            var uowMock = new Mock<IUnitOfWork>();

            var sut = new TransportationService(uowMock.Object, _mapper, driverSalaryMock.Object, carDriverMock.Object);

            // Act
            var actual = sut.GetSalary(800, 8, 1);


            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task GetCostOfTransportation_ReturnsCostOfTransportation()
        {
            // Arrange
            var expected = 15000;

            var carDriverMock = new Mock<ICarDriverService>();
            var driverSalaryMock = new Mock<IDriverSalaryService>();
            var uowMock = new Mock<IUnitOfWork>();

            var sut = new TransportationService(uowMock.Object, _mapper, driverSalaryMock.Object, carDriverMock.Object);

            // Act
            var actual = sut.GetCostOfTransportation(800, 25);


            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task AddTransportation_ReturnsTransportation()
        {
            // Arrange
            var transportationDto = new TransportationDTO() { Id = 1, Distance = 800, Cost = 15000, CarId = 1 };

            var transportation = new Transportation() { Id = 1, Distance = 800, Cost = 15000, Status = TransportationStatus.Formed, CarId = 1};

            var car = new Car { Id = 1, FuelConsumption = 25, Status = CarStatus.Free};

            var driverSalaryRepositoryMock = new Mock<IDriverSalaryRepository>();
            var carDriverRepositoryMock = new Mock<ICarDriverRepository>();

            var carRepositoryMock = new Mock<ICarRepository>();
            carRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(car);
            carRepositoryMock.Setup(x => x.UpdateAsync(car)).ReturnsAsync(car);

            var transportationRepositoryMock = new Mock<ITransportationRepository>();
            transportationRepositoryMock.Setup(x => x.AddAsync(transportation)).ReturnsAsync(transportation);

            var UOWMock = new UnitOfWorkMock().GetAllRepositoryMock(
                carRepositoryMock,
                carDriverRepositoryMock, 
                driverSalaryRepositoryMock, 
                transportationRepositoryMock);

            var driverSalaryServiceMock = new Mock<IDriverSalaryService>();
            var carDriverServiceMock = new Mock<ICarDriverService>();

            var carService = new TransportationService(
                UOWMock.Object, 
                _mapper, 
                driverSalaryServiceMock.Object, 
                carDriverServiceMock.Object);

            // Act
            var cars = await carService.AddTransportationAsync(transportationDto);

            // Assert
            Assert.NotNull(cars);
        }

        [Fact]
        public async Task NextStageAsync_ShouldReturn_True_When_StateChanged()
        {
            // Arrange
            var transportation = new Transportation() { Id = 1, Status = TransportationStatus.OnUnloading, CarId = 1 };
            var car = new Car { Id = 1, Status = CarStatus.Busy };
            var carDrivers = new List<CarDriver>
            {
                new CarDriver {Id = 1, Status = CarDriverStatus.Busy,},
                new CarDriver {Id = 2, Status = CarDriverStatus.Busy,},
            };

            var driverSalaryRepositoryMock = new Mock<IDriverSalaryRepository>();

            var carDriverRepositoryMock = new Mock<ICarDriverRepository>();
            carDriverRepositoryMock.Setup(x => x.GetCarDriversByTransportationId(1)).ReturnsAsync(carDrivers);

            var carRepositoryMock = new Mock<ICarRepository>();
            carRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(car);
            carRepositoryMock.Setup(x => x.UpdateAsync(car)).ReturnsAsync(car);

            var transportationRepositoryMock = new Mock<ITransportationRepository>();
            transportationRepositoryMock.Setup(x => x.UpdateAsync(transportation)).ReturnsAsync(transportation);
            transportationRepositoryMock.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(transportation);

            var UOWMock = new UnitOfWorkMock().GetAllRepositoryMock(
                carRepositoryMock,
                carDriverRepositoryMock,
                driverSalaryRepositoryMock,
                transportationRepositoryMock);

            var driverSalaryServiceMock = new Mock<IDriverSalaryService>();
            var carDriverServiceMock = new Mock<ICarDriverService>();

            var carService = new TransportationService(
                UOWMock.Object,
                _mapper,
                driverSalaryServiceMock.Object,
                carDriverServiceMock.Object);

            // Act
            var actual = await carService.NextStageAsync(1);

            // Assert
            Assert.True(actual);
        }
    }
}