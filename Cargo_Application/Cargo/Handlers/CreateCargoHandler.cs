using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Cargo.Commands;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Cargo.Handlers
{
    public class CreateCargoHandler : IRequestHandler<CreateCargoCommand, bool>
    {
        private readonly ICargoService _cargoService;
        public CreateCargoHandler(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<bool> Handle(CreateCargoCommand request, CancellationToken cancellationToken)
        {
            return await _cargoService.CreateCargo(request.CargoDto);
        }
    }
}