using FreightTransport_Client.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreightTransport_Client.Data.Enums;

namespace FreightTransport_Client.Data.Interfaces
{
    public interface ICarService
    {
        Task<CarModel> GetCarById(int id);
        Task<IEnumerable<CarModel>> GetAllCars();
        Task<bool> AddCar(CarModel car);
        Task<bool> UpdateCar(CarModel car);
        Task<bool> DeleteCar(int id);

        Task<ResponceCarsModel> GetFreeCarsOfSelectedType(CarType carType);
    }
}
