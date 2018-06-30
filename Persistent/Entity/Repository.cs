using Common.CustomFilters;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RoomM.API.Persistent.Entity
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        private IQueryable<T> PerformInclusions(IEnumerable<Expression<Func<T, object>>> includeProperties,
                                                       IQueryable<T> query)
        {
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        #region IRepository<T> Members
        public async Task<IQueryable<T>> AsQueryable()
        {
            var list = await Context.Set<T>().ToListAsync();
            return list.AsQueryable();
        }

        public async Task<IEnumerable<T>> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public async Task<T> Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.SingleAsync(where);
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.SingleOrDefaultAsync(where);
        }

        public async Task<T> First(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.FirstAsync(where);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = await AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return await query.FirstOrDefaultAsync(where);
        }

        public void Delete(T entity)
        {
            if (entity is ISoftDeleted)
            {
                ((ISoftDeleted)entity).Deleted = true;

                Context.Set<T>().Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                Context.Set<T>().Remove(entity);
            }
        }

        public void Insert(T entity)
        {
            Context.Set<T>().AddAsync(entity);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void Insert(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                Context.Entry(e).State = EntityState.Added;
            }
        }

        public void Update(IEnumerable<T> entities)
        {
            foreach (var e in entities)
            {
                Context.Entry(e).State = EntityState.Modified;
            }
        }
        #endregion

        #region SQL Queries
        public virtual IQueryable<T> SelectQuery(string query, params object[] parameters)
        {
            return Context.Set<T>().FromSql(query, parameters).AsQueryable();
        }

        public virtual async Task<int> ExecuteSqlCommand(string query, params object[] parameters)
        {
            return await Context.Database.ExecuteSqlCommandAsync(query, parameters);
        }
        #endregion
    }
}
