using Microsoft.EntityFrameworkCore;
using noon.Context.Context;
using noon.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noon.Infrastructure.GenericRepository
{
    public class GenericRepository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        private readonly noonContext _context;
        private readonly DbSet<TEntity> _DbSet;

        public GenericRepository(noonContext context)
        {
            _context = context;
            _DbSet = _context.Set<TEntity>();
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

        public async Task<bool> DeleteAsync(TId TId)
        {
            var TEntity = await GetByIdAsync(TId);
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

        public Task<int> SaveChanges()
        {
            return Task.FromResult(_context.SaveChanges());
        }
    }
}
