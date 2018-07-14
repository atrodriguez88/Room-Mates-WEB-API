using System.Linq;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Common.MyExtensions
{
    public static class RoomExtension
    {
        public static IQueryable<Room> ApplyFiltering (this IQueryable<Room> query, RoomQuery queryObj)
        {

            // This filter return a bool is for that I do the else sentence
            
             if (queryObj.IsFurnished.HasValue && queryObj.IsFurnished == 1)
                query = query.Where(r => r.IsFurnished);
            if (queryObj.IsFurnished.HasValue && queryObj.IsFurnished == 0)
                query = query.Where(r => r.IsFurnished == false);

            if (queryObj.Pet != null)
                query = query.Where(r => r.Pet == queryObj.Pet);

            //  ...

            return query;

        }
    }
}