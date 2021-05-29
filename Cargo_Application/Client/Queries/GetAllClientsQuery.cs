using System.Collections.Generic;
using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Client.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<ClientDTO>>
    {
        
    }
}