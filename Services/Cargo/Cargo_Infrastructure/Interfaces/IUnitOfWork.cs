using Cargo_Infrastructure.Interfaces.IRepositories;

namespace Cargo_Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IClientRepository ClientRepository { get; }
        ICargoRepository CargoRepository { get; }
    }
}