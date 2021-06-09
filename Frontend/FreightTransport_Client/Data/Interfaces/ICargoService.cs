using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface ICargoService
    {
        Task<CargoModel> GetCargoById(int id);
        Task<IEnumerable<CargoTableModel>> GetAllCargoTableModels();
        Task<bool> AddCargo(CargoModel car);
        Task<bool> UpdateCargo(CargoModel car);
        Task<bool> DeleteCargo(int id);

        Task<IEnumerable<CargoTableModel>> GetAllCargoModelsWithoutTransportation();
        Task<IEnumerable<CargoTableModel>> GetAllCargoModelsBytransportationId(int id);
        Task<bool> RemoveCargoFromTransportation(int id);
        Task<bool> AddCargoToTransportation(int cargoId, int transportationId);

    }
}