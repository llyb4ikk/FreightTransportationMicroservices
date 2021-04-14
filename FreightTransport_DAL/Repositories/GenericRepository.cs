using FreightTransport_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreightTransport_DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    {
        public async Task<TEntity> Add(TEntity obj)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Update(TEntity obj)
        {
            throw new NotImplementedException();
        }
    }
}
