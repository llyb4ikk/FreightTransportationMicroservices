using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Cargo.Commands
{
    public class CreateCargoCommand : IRequest<bool>
    {
        public CargoDTO CargoDto { get; }
        public CreateCargoCommand(CargoDTO cargoDto)
        {
            CargoDto = cargoDto;
        }
    }
}