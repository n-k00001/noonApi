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
using static Dapper.SqlMapper;

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
            var model = (await _DbSet.AddAsync(TEntity)).Entity;
            await SaveChanges();
            return model;
        }

        public virtual Task<IQueryable<TEntity>> GetAllAsync()
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
                await SaveChanges();
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
                await SaveChanges();
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
            // var re = await noonContext.FindAsync(entityType, id);
            var re = await noonContext.FindAsync(entityType, id);

            return (TEntity)re;
        }



        //async Task<TEntity> IRepository<TEntity, TId>.UpdateAsync(TEntity TEntity)
        //{
        //    if (TEntity != null)
        //    {
        //        _DbSet.Update(TEntity);
        //        await SaveChanges();
        //        return TEntity;
        //    }
        //    else
        //    {
        //        return TEntity;
        //    }
        //}
    }
}
