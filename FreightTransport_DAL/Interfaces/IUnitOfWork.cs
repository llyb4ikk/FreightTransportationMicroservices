using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        ICarDriverRepository CarDriverRepository { get; }
        ICargoRepository CargoRepository { get; }
        ICityRepository CityRepository { get; }
        IDriverSalaryRepository DriverSalaryRepository { get; }
        IClientRepository ClientRepository { get; }
        ITransportationRepository TransportationRepository { get; }
    }
}