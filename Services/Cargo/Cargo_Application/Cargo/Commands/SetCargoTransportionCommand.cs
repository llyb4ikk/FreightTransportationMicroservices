using MediatR;

namespace Cargo_Application.Cargo.Commands
{
    public class SetCargoTransportionCommand : IRequest<bool>
    {
        public SetCargoTransportionCommand(int cargoId, int? transportationId)
        {
            CargoId = cargoId;
            TransportationId = transportationId;
        }

        public int CargoId { get; }
        public int? TransportationId { get; }
    }
}