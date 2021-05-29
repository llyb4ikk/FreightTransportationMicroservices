using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Cargo.Queries;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using Cargo_Infrastructure.Interfaces.IRepositories;
using MediatR;

namespace Cargo_Application.Cargo.Handlers
{
    public class GetCargosByTransportationHandler : IRequestHandler<GetCargosByTransportationQuery, IEnumerable<CargoDTO>>
    {
        private readonly ICargoService _cargoService;
        public GetCargosByTransportationHandler(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        public async Task<IEnumerable<CargoDTO>> Handle(GetCargosByTransportationQuery request, CancellationToken cancellationToken)
        {
            return await _cargoService.GetCargosByTransportation(request.TransportationId);
        }
    }
}