using FreightTransport_DAL.Interfaces;
using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarDriverRepository _carDriverRepository;
        private readonly ITransportationRepository _transportationRepository;
        private readonly IDriverSalaryRepository _driverSalaryRepository;


        public UnitOfWork(
            ICarDriverRepository carDriverRepository,
            ICarRepository carRepository,
            ITransportationRepository transportationRepository, 
            IDriverSalaryRepository driverSalaryRepository
            )
        {
            _carDriverRepository = carDriverRepository;
            _carRepository = carRepository;
            _transportationRepository = transportationRepository;
            _driverSalaryRepository = driverSalaryRepository;
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

    }
}
