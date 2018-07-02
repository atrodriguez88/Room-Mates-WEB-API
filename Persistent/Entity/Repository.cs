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

        #region IRepository<T> Members
        private DbSet<T> DbSet()
        {
            return Context.Set<T>();
        }

        public IAsyncEnumerable<T> Include(Expression<Func<T, object>> where)
        {
           return DbSet().Include(where).ToAsyncEnumerable();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
           return await DbSet().ToListAsync();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where)
        {
            return DbSet().Where(where);
        }

        public async Task<T> Single(Expression<Func<T, bool>> where)
        {
            return await DbSet().SingleAsync(where);
        }

        public async Task<T> SingleOrDefault(Expression<Func<T, bool>> where)
        {
            return await DbSet().SingleAsync(where);
        }

        public async Task<T> First(Expression<Func<T, bool>> where)
        {
            return await DbSet().FirstAsync(where);
        }

        public async Task<T> FirstOrDefault(Expression<Func<T, bool>> where)
        {
            return await DbSet().FirstOrDefaultAsync(where);
        }

        public void Delete(T entity)
        {
            if (entity is ISoftDeleted)
            {
                ((ISoftDeleted)entity).Deleted = true;

                DbSet().Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                DbSet().Remove(entity);
            }
        }

        public async Task Insert(T entity)
        {
            await DbSet().AddAsync(entity);
        }

        public void Update(T entity)
        {
            DbSet().Attach(entity);
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
            return DbSet().FromSql(query, parameters).AsQueryable();
        }

        public virtual async Task<int> ExecuteSqlCommand(string query, params object[] parameters)
        {
            return await Context.Database.ExecuteSqlCommandAsync(query, parameters);
        }
        #endregion
    }
}
