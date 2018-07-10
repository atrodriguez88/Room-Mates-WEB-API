using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RoomM.API.Common.MyExtensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IQueryObj queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (queryObj.SortBy == null)
            {
                return query;
            }
            return queryObj.IsSortAsc ? query.OrderBy(columnsMap[queryObj.SortBy.ToLower()]) : query.OrderByDescending(columnsMap[queryObj.SortBy.ToLower()]);

        }
    }
}
