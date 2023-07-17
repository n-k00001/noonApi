using Microsoft.EntityFrameworkCore;
using noon.Context.Context;
using noon.Domain.Contract;
using noon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure
{
    public class Repositoy<TEntity,TId> : IRepository<TEntity,TId> where TEntity : class
    {
        private readonly noonContext noonContext;
        private readonly DbSet<TEntity> _DbSet;

        public Repositoy(noonContext noonContext)
        {
            this.noonContext = noonContext;
            _DbSet = noonContext.Set<TEntity>();      
        }
        public async Task<TEntity> CreateAsync(TEntity TEntity)
        {
            var entity = (await _DbSet.AddAsync(TEntity)).Entity;
            await SaveChanges();
            return entity;

        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            
                return Task.FromResult(_DbSet.Select(T => T));
            
        }

        public async Task<TEntity> GetByIdAsync(TId TId)
        {
            return (await GetDetailsAsync(TId));
        }
        public Task<int> SaveChanges()
        {
            return Task.FromResult(noonContext.SaveChanges());
        }
        public async Task<bool> DeleteAsync(TId id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return false;
            _DbSet.Remove(entity);
            await SaveChanges();
            return true;
        }


        public async Task<TEntity> UpdateAsync(TEntity TEntity)
        {
            var entity = (_DbSet.Update(TEntity)).Entity;
            await SaveChanges();
            return entity;
        }
        public virtual async Task<TEntity> GetDetailsAsync(TId id)
        {
            var entityType = typeof(TEntity);
            var re = await noonContext.FindAsync(entityType, id);
            return (TEntity)re;
        }
    }
}
