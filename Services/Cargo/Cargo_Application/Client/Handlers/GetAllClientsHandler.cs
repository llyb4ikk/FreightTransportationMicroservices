using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Client.Queries;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Client.Handlers
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<ClientDTO>>
    {
        private readonly IClientService _clientService;
        public GetAllClientsHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<IEnumerable<ClientDTO>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            return await _clientService.GetAllClients();
        }
    }
}