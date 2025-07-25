﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    public abstract class EfGenericRepository<TEntity,TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        //private:sadece tanımlandığımız sınıf içinde erişilebilir.
        //protected: tanımlandığımız sınıf ve o sınıftan türetilen sınıflar içinde erişilebilir.
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> _dbSet;

        protected EfGenericRepository(TContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.FirstOrDefaultAsync(filter);
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null ? _dbSet : _dbSet.Where(filter);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
           return await _dbSet.AnyAsync(filter);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

    }
}
