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
        private readonly IRouteRepository _routeRepository;
        private readonly ITransportationRepository _transportationRepository;


        public UnitOfWork(
            ICarDriverRepository carDriverRepository,
            ICarRepository carRepository, 
            ICargoRepository cargoRepository, 
            ICityRepository cityRepository, 
            IRouteRepository routeRepository, 
            ITransportationRepository transportationRepository)
        {
            _carDriverRepository = carDriverRepository;
            _carRepository = carRepository;
            _cargoRepository = cargoRepository;
            _cityRepository = cityRepository;
            _routeRepository = routeRepository;
            _transportationRepository = transportationRepository;
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

        public IRouteRepository RouteRepository
        {
            get
            {
                return _routeRepository;
            }
        }

        public ITransportationRepository TransportationRepository
        {
            get
            {
                return _transportationRepository;
            }
        }
    }
}
