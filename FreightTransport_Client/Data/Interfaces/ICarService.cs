using FreightTransport_Client.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface ICarService
    {
        Task<CarModel> GetCarById(int id);
        Task<IEnumerable<CarModel>> GetAllCars();
        Task<CarModel> AddCar(CarModel car);
    }
}
