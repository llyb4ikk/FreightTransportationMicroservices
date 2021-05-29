using System.Collections.Generic;
using System.Threading.Tasks;
using Cargo_Application.DTOs;

namespace Cargo_Application.Interfaces
{
    public interface ICargoService
    {
        Task<CargoDTO> GetCargoById(int id);
        Task<IEnumerable<CargoDTO>> GetAllCargos();
        Task<IEnumerable<CargoDTO>> GetCargosByTransportation(int transportationId);
        Task<IEnumerable<CargoDTO>> GetCargosByOwner(int ownerId);
        Task<IEnumerable<CargoInformationDTO>> GetCargosInformationByTransportation(int transportationId);
        Task<bool> SetCargoTransportation(int cargoId, int? transportationId);
        Task<IEnumerable<CargoInformationDTO>> GetAllCargosInformation();

        Task<bool> CreateCargo(CargoDTO cargoDto);

        Task<CargoDTO> UpdateCargo(CargoDTO cargoDto);

        Task<bool> DeleteCargo(int id);
    }
}