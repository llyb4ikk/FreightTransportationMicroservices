using FreightTransport_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreightTransport_DAL.Enums;

namespace FreightTransport_DAL.Interfaces.IRepositories
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IEnumerable<Car>> GetFreeCarsOfCartype(CarType carType);
    }
}
