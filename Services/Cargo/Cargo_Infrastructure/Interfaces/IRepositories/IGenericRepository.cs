using Cargo_Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cargo_Infrastructure.Interfaces.IRepositories
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<TEntity> GetByIdAsync(int Id);
        public Task<bool> AddAsync(TEntity entity);
        public Task<bool> UpdateAsync(TEntity entity);
        public Task<bool> DeleteAsync(int Id);
    }
}