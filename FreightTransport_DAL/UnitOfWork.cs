using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarTypeRepository _carTypeRepository;
        private readonly ICarDriverRepository _carDriverRepository;
        private readonly ICargoRepository _cargoRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IRouteRepository _routeRepository;
        private readonly ITransportationRepository _transportationRepository;


        public UnitOfWork(
            ICarDriverRepository carDriverRepository, 
            ICarTypeRepository carTypeRepository, 
            ICarRepository carRepository, 
            ICargoRepository cargoRepository, 
            ICityRepository cityRepository, 
            IRegionRepository regionRepository, 
            IRouteRepository routeRepository, 
            ITransportationRepository transportationRepository)
        {
            _carDriverRepository = carDriverRepository;
            _carTypeRepository = carTypeRepository;
            _carRepository = carRepository;
            _cargoRepository = cargoRepository;
            _cityRepository = cityRepository;
            _regionRepository = regionRepository;
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

        public ICarTypeRepository CarTypeRepository
        {
            get
            {
                return _carTypeRepository;
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

        public IRegionRepository RegionRepository
        {
            get
            {
                return _regionRepository;
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
