using System.Collections.Generic;
using System.Threading.Tasks;
using FreightTransport_BLL.DTOs;

namespace FreightTransport_BLL.Interfaces.IServices
{
    public interface ICarDriverService
    {
        Task<CarDriverDTO> GetCarDriverByIdAsync(int id);
        //Task<CarDriverDTO> GetCarDriverByNameAsync(string name);
        Task<IEnumerable<CarDriverDTO>> GetAllCarDriversAsync();
        Task<CarDriverDTO> AddCarDriverAsync(CarDriverDTO carDriverDto);
        Task<CarDriverDTO> EditCarDriverAsync(CarDriverDTO carDriverDto);
        Task<bool> DeleteCarDriverAsync(int id);
    }
}