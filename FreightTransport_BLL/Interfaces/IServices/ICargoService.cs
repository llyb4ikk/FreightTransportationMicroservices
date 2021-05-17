using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface ICargoService
    {
        Task<CargoDTO> GetCargoByIdAsync(int id);
        Task<IEnumerable<CargoDTO>> GetAllCargosAsync();
        Task<CargoDTO> AddCargoAsync(CargoDTO cargoDto);
        Task<CargoDTO> EditCargoAsync(CargoDTO cargoDto);
        Task<bool> DeleteCargoAsync(int id);

        Task<IEnumerable<CargoDetailsDTO>> GetAllCargosWithOwnersByTransportationId(int id);
        Task<IEnumerable<CargoDetailsDTO>> GetAllCargosWithOwnersWithputTransportation();
        Task<IEnumerable<CargoDetailsDTO>> GetAllCargosWithOwner();
        Task<CargoDTO> AddCargoToTransportation(int cargoId, int transportationId);
        Task<CargoDTO> RemoveCargoToTransportation(int cargoId);


    }
}