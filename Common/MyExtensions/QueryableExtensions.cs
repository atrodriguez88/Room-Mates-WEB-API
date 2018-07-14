using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Common.MyExtensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplySorting<T>(this IQueryable<T> query, IQuerySort querySort, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(querySort.SortBy) || !columnsMap.ContainsKey(querySort.SortBy))
            {
                return query;
            }
            return querySort.IsSortAsc ? query.OrderBy(columnsMap[querySort.SortBy.ToLower()]) : query.OrderByDescending(columnsMap[querySort.SortBy.ToLower()]);

        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryPage queryPage)
        {
            if (queryPage.Page <= 0)
                queryPage.Page = 1;
            if (queryPage.PageSize <= 0)
                queryPage.PageSize = 10;
            return query.Skip((queryPage.Page - 1) * queryPage.PageSize).Take(queryPage.PageSize);
        }
    }
}
