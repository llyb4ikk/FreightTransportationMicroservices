using System.Collections.Generic;
using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Cargo.Queries
{
    public class GetAllCargosInformationQuery : IRequest<IEnumerable<CargoInformationDTO>>
    {
        
    }
}