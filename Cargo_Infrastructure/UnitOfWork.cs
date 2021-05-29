using Cargo_Infrastructure.Interfaces;
using Cargo_Infrastructure.Interfaces.IRepositories;

namespace Cargo_Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IClientRepository _clientRepository;
        private readonly ICargoRepository _cargoRepository;

        public UnitOfWork(IClientRepository clientRepository, ICargoRepository cargoRepository)
        {
            _clientRepository = clientRepository;
            _cargoRepository = cargoRepository;
        }

        public IClientRepository ClientRepository
        {
            get => _clientRepository;
        }

        public ICargoRepository CargoRepository
        {
            get => _cargoRepository;
        }
    }
}