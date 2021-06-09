using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Client.Commands
{
    public class CreateClientCommand : IRequest<bool>
    {
        public ClientDTO ClientDto { get; }
        public CreateClientCommand(ClientDTO clientDto)
        {
            ClientDto = clientDto;
        }
    }
}