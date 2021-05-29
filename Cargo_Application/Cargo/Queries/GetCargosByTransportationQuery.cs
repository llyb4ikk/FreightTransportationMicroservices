using System.Collections.Generic;
using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Cargo.Queries
{
    public class GetCargosByTransportationQuery : IRequest<IEnumerable<CargoDTO>>
    {
        public int TransportationId { get; }
        public GetCargosByTransportationQuery(int transportationId) => TransportationId = transportationId;

    }
}