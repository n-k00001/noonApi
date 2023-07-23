using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace noon.Domain.Contract
{
    public interface IRepository<TEntity,TId>
    {
        public Task<TEntity> CreateAsync(TEntity TEntity);
        public Task<TEntity> GetByIdAsync(TId TId);
        public Task<IQueryable<TEntity>> GetAllAsync();
        public Task<bool> UpdateAsync(TEntity TEntity);
        public Task<bool> DeleteAsync(TId TId);
        public Task<int> SaveChanges();
        public Task<TEntity?> GetDetailsAsync(TId id);

    }
}
