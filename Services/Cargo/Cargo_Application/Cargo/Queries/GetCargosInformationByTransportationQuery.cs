using System.Collections.Generic;
using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Cargo.Queries
{
    public class GetCargosInformationByTransportationQuery : IRequest<IEnumerable<CargoInformationDTO>>
    {
        public int TransportationId { get; }
        public GetCargosInformationByTransportationQuery(int transportationId) => TransportationId = transportationId;
    }
}