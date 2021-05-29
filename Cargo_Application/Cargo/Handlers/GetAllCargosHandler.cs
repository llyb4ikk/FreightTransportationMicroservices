using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Cargo.Queries;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Cargo.Handlers
{
    public class GetAllCargosHandler : IRequestHandler<GetAllCargosQuery, IEnumerable<CargoDTO>>
    {
        private readonly ICargoService _cargoService;
        public GetAllCargosHandler(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<IEnumerable<CargoDTO>> Handle(GetAllCargosQuery request, CancellationToken cancellationToken)
        {
            return await _cargoService.GetAllCargos();
        }
    }
}