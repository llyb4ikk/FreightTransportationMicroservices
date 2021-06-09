using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Cargo.Queries;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Cargo.Handlers
{
    public class GetAllCargosInformationHandler : IRequestHandler<GetAllCargosInformationQuery, IEnumerable<CargoInformationDTO>>
    {
        private readonly ICargoService _cargoService;

        public GetAllCargosInformationHandler(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<IEnumerable<CargoInformationDTO>> Handle(GetAllCargosInformationQuery request, CancellationToken cancellationToken)
        {
            return await _cargoService.GetAllCargosInformation();
        }
    }
}