using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Models;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface ICarDriverService
    {
        Task<CarDriverModel> GetCarDriverById(int id);
        Task<IEnumerable<CarDriverModel>> GetAllCarDrivers();
        Task<bool> AddCarDriver(CarDriverModel car);
        Task<bool> UpdateCarDriver(CarDriverModel car);
        Task<bool> DeleteCarDriver(int id);

        Task<IEnumerable<CarDriverModel>> GetAllFreeCarDrivers();
    }
}