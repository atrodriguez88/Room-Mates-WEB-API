using System.Linq;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Common.MyExtensions
{
    public static class ProfileExtension
    {
        public static IQueryable<Profile> ApplyFiltering(this IQueryable<Profile> query, ProfileQuery queryObj)
        {
            if (queryObj.Age.HasValue)
                query = query.Where(p => p.Age == queryObj.Age);
            if (queryObj.Gender != null)
                query = query.Where(p => p.Gender == queryObj.Gender);
            if (queryObj.Ocupation.HasValue)
                query = query.Where(p => p.OcupationId == queryObj.Ocupation);
            if (queryObj.Address != null)
                query = query.Where(p => p.Address == queryObj.Address);

            return query;
        }
    }
}