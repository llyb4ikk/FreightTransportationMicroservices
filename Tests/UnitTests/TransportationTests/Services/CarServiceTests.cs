using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FreightTransport.Mapping;
using FreightTransport_BLL.DTOs;
using FreightTransport_BLL.Services;
using FreightTransport_DAL.Entities;
using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;
using Moq;
using TransportationTests.Infrastructure.Mocks;
using Xunit;

namespace TransportationTests.Services
{
    public class CarServiceTests
    {
        //private readonly CarService _sut;
        //private readonly Mock<IUnitOfWork> _ouwMock = new Mock<IUnitOfWork>();
        //private readonly Mock<ICarRepository> _carRepositoryMock = new Mock<ICarRepository>();
        private readonly IMapper _mapper;

        public CarServiceTests()
        {
            //var mappingProfile = new MainMappingProfile();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MainMappingProfile>();
            });
            _mapper = new Mapper(mapperConfig);
        }


        [Fact]
        public async Task GetAllCars_ReturnsIenumerableCars()
        {
            // Arrange
            var CarsMock = new List<Car>
            {
                new Car()
            };

            //var CarRepositoryMock = await new CarRepositoryMock().MockGetAll(CarsMock);
            var CarRepositoryMock = await new CarRepositoryMock().MockGetAll(CarsMock);

            var UOWMock = new UnitOfWorkMock().GetCarRepositoryMock(CarRepositoryMock.Object);

            var mockMapper = new Mock<IMapper>();
            //mockMapper.Setup(x => x.ConfigurationProvider)

            var carService = new CarService(UOWMock.Object, mockMapper.Object);

            // Act
            var cars = await carService.GetAllCarsAsync();

            // Assert
            Assert.NotNull(cars);
        }

        [Fact]
        public async Task GetCarById_ReturnsCar()
        {
            // Arrange
            var car = new Car
            {
                Id = 1,
                Model = "kamaz"
            };

            var expected = _mapper.Map<CarDTO>(car);

            var CarRepositoryMock = await new CarRepositoryMock().GetByIdMock(car);
            var UOWMock = new UnitOfWorkMock().GetCarRepositoryMock(CarRepositoryMock.Object);

            var carService = new CarService(UOWMock.Object, _mapper);

            // Act
            var actual = await carService.GetCarByIdAsync(1);

            // Assert
            Assert.NotNull(car);
            Assert.Equal(expected.Id, actual.Id);
        }

        [Fact]
        public async Task GetFreeCarsOfSelectedType_ReturnsFreeCarsByCarType()
        {
            // Arrange
            var car = new Car
            {
                Id = 1,
                Model = "kamaz"
            };

            var expected = _mapper.Map<CarDTO>(car);

            var CarRepositoryMock = await new CarRepositoryMock().GetByIdMock(car);
            var UOWMock = new UnitOfWorkMock().GetCarRepositoryMock(CarRepositoryMock.Object);

            var carService = new CarService(UOWMock.Object, _mapper);

            // Act
            var actual = await carService.GetCarByIdAsync(1);

            // Assert
            Assert.NotNull(car);
            Assert.Equal(expected.Id, actual.Id);
        }
    }
}