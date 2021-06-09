﻿using FreightTransport_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Interfaces.IRepositories
{
    public interface ICarDriverRepository : IGenericRepository<CarDriver>
    {
        Task<IEnumerable<CarDriver>> GetFreeCarDriversAsync();
        Task<IEnumerable<CarDriver>> GetCarDriversByTransportationId(int transportationId);
    }
}
