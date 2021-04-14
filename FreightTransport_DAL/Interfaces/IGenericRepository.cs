using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
    {
        Task<TEntity> Add(TEntity obj);
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task<TEntity> Update(TEntity obj);
        Task<TEntity> Delete(int id);
    }
}
