using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Cargo.Queries;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Cargo.Handlers
{
    public class GetCargosInformationByTransportationHandler : IRequestHandler<GetCargosInformationByTransportationQuery, IEnumerable<CargoInformationDTO>>
    {
        private readonly ICargoService _cargoService;
        public GetCargosInformationByTransportationHandler(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<IEnumerable<CargoInformationDTO>> Handle(GetCargosInformationByTransportationQuery request, CancellationToken cancellationToken)
        {
            return await _cargoService.GetCargosInformationByTransportation(request.TransportationId);
        }
    }
}