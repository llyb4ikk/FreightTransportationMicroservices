using Cargo_Application.DTOs;
using MediatR;

namespace Cargo_Application.Cargo.Queries
{
    public class GetCargoByIdQuery : IRequest<CargoDTO>
    {
        public int Id { get; }
        public GetCargoByIdQuery(int id)
        {
            Id = id;
        }
    }
}