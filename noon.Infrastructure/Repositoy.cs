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
            return (await _DbSet.AddAsync(TEntity)).Entity;
        }

        public Task<IQueryable<TEntity>> GetAllAsync()
        {
            
            return Task.FromResult(_DbSet.Select(T => T));

        }

        public async Task<TEntity> GetByIdAsync(TId TId)
        {
            return (await _DbSet.FindAsync(TId));
        }
        public Task<int> SaveChanges()
        {
            return Task.FromResult(noonContext.SaveChanges());
        }
        public async Task<bool> DeleteAsync(TId id)
        {
            var TEntity = await GetByIdAsync(id);
            if (TEntity != null)
            {
                _DbSet.Remove(TEntity);
                return true;

            }
            else
            {
                return false;
            }
        }


        public async Task<bool> UpdateAsync(TEntity TEntity)
        {
            if (TEntity != null)
            {
                _DbSet.Update(TEntity);
                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual async Task<TEntity> GetDetailsAsync(TId id)
        {
            var entityType = typeof(TEntity);
            var re = await noonContext.FindAsync(entityType, id);
            return (TEntity)re;
        }

        Task<TEntity> IRepository<TEntity, TId>.UpdateAsync(TEntity TEntity)
        {
            throw new NotImplementedException();
        }
    }
}
