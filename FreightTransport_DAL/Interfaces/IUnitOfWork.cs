using FreightTransport_DAL.Interfaces.IRepositories;

namespace FreightTransport_DAL.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        ICarDriverRepository CarDriverRepository { get; }
        ICarTypeRepository CarTypeRepository { get; }
        ICargoRepository CargoRepository { get; }
        IRegionRepository RegionRepository { get; }
        ICityRepository CityRepository { get; }
        IRouteRepository RouteRepository { get; }
        ITransportationRepository TransportationRepository { get; }
    }
}