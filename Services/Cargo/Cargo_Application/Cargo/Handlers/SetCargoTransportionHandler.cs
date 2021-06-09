using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Cargo.Commands;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Cargo.Handlers
{
    public class SetCargoTransportionHandler : IRequestHandler<SetCargoTransportionCommand, bool>
    {
        private readonly ICargoService _cargoService;

        public SetCargoTransportionHandler(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<bool> Handle(SetCargoTransportionCommand request, CancellationToken cancellationToken)
        {
            return await _cargoService.SetCargoTransportation(request.CargoId, request.TransportationId);
        }
    }
}