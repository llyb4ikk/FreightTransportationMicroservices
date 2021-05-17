using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarDriverRepository _carDriverRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ITransportationRepository _transportationRepository;
        private readonly IDriverSalaryRepository _driverSalaryRepository;
        private readonly IClientRepository _clientRepository;


        public UnitOfWork(
            ICarDriverRepository carDriverRepository,
            ICarRepository carRepository, 
            ICargoRepository cargoRepository, 
            ICityRepository cityRepository,
            ITransportationRepository transportationRepository, 
            IDriverSalaryRepository driverSalaryRepository, 
            IClientRepository clientRepository)
        {
            _carDriverRepository = carDriverRepository;
            _carRepository = carRepository;
            _cargoRepository = cargoRepository;
            _cityRepository = cityRepository;
            _transportationRepository = transportationRepository;
            _driverSalaryRepository = driverSalaryRepository;
            _clientRepository = clientRepository;
        }

        public ICarRepository CarRepository
        {
            get
            {
                return _carRepository;
            }
        }

        public ICarDriverRepository CarDriverRepository
        {
            get
            {
                return _carDriverRepository;
            }
        }

        public ICargoRepository CargoRepository
        {
            get
            {
                return _cargoRepository;
            }
        }

        public ICityRepository CityRepository
        {
            get
            {
                return _cityRepository;
            }
        }


        public ITransportationRepository TransportationRepository
        {
            get
            {
                return _transportationRepository;
            }
        }
        public IDriverSalaryRepository DriverSalaryRepository
        {
            get
            {
                return _driverSalaryRepository;
            }
        }


        public IClientRepository ClientRepository
        {
            get
            {
                return _clientRepository;
            }
        }
    }
}
