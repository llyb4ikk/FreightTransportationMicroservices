using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;
using FreightTransport_DAL.Enums;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface ICarService
    {
        Task<CarDTO> GetCarByIdAsync(int id);
        Task<IEnumerable<CarDTO>> GetAllCarsAsync();
        Task<CarDTO> AddCarAsync(CarDTO carDto);
        Task<CarDTO> EditCarAsync(CarDTO carDto);
        Task<bool> DeleteCarAsync(int id);

        Task<IEnumerable<CarDTO>> GetFreeCarsOfSelectedType(CarType carType);
    }
}