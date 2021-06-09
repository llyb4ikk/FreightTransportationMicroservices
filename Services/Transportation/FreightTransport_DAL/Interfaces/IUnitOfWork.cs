using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        ICarDriverRepository CarDriverRepository { get; }
        IDriverSalaryRepository DriverSalaryRepository { get; }
        ITransportationRepository TransportationRepository { get; }
    }
}