using Common.CustomFilters;
using Microsoft.EntityFrameworkCore;
using RoomM.API.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public IQueryable<T> AsQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            return PerformInclusions(includeProperties, query);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Where(where);
        }

        public T Single(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.Single(where);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.SingleOrDefault(where);
        }

        public T First(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.First(where);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AsQueryable();
            query = PerformInclusions(includeProperties, query);
            return query.FirstOrDefault(where);
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
            Context.Set<T>().Add(entity);
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

        public virtual int ExecuteSqlCommand(string query, params object[] parameters)
        {
            return Context.Database.ExecuteSqlCommand(query, parameters);
        }
        #endregion
    }
}
