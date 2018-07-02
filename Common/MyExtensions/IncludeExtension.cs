using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RoomM.API.Common.MyExtensions
{
    public static class IncludeExtension
    {
        public static IQueryable<TEntity> Include<TEntity>(this IQueryable<TEntity> dbSet,
                                                params Expression<Func<TEntity, object>>[] includes)
                                                where TEntity : class
        {
            IQueryable<TEntity> query = null;
            foreach (var include in includes)
            {
                query = dbSet.Include(include);
            }

            return query == null ? dbSet : query;
        }
    }
}
