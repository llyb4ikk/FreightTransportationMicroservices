using System.Threading;
using System.Threading.Tasks;
using Cargo_Application.Client.Commands;
using Cargo_Application.DTOs;
using Cargo_Application.Interfaces;
using MediatR;

namespace Cargo_Application.Client.Handlers
{
    public class CreateClientHandler : IRequestHandler<CreateClientCommand, bool>
    {
        private readonly IClientService _clientService;
        public CreateClientHandler(IClientService clientService)
        {
            _clientService = clientService;
        }

        public async Task<bool> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            return await _clientService.CreateClient(request.ClientDto);
        }
    }
}