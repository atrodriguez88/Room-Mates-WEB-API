using Microsoft.EntityFrameworkCore;
using RoomM.API.Common.MyExtensions;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;
using RoomM.API.Core.Repository;
using RoomM.API.Persistent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RoomM.API.Persistent.Repository
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        private readonly RoomMDbContext context;

        public ProfileRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Profile> GetProfile(int id)
        {
            return await context.Profiles.Include(p => p.Ocupation)
                .SingleOrDefaultAsync(p => p.Id == id && p.Deleted == false);
        }

        public async Task<IEnumerable<Profile>> GetProfiles(ProfileQuery queryObj)
        {
            var query = context.Profiles.Include(p => p.Ocupation)
                .Where(p => p.Deleted == false);

            /*
                Filter
            */

            if (queryObj.Age.HasValue)
                query = query.Where(p => p.Age == queryObj.Age);
            if (queryObj.Gender != null)
                query = query.Where(p => p.Gender == queryObj.Gender);
            if (queryObj.Ocupation.HasValue)
                query = query.Where(p => p.OcupationId == queryObj.Ocupation);
            if (queryObj.Address != null)
                query = query.Where(p => p.Address == queryObj.Address);

            /*
                Sorting
            */

            var columnsMap = new Dictionary<string, Expression<Func<Profile, object>>>()
            {
                ["age"] = profile => profile.Age,
                ["gender"] = profile => profile.Gender,
                ["ocupation"] = profile => profile.Ocupation,
                ["address"] = profile => profile.Address
            };

            query = query.ApplySorting(queryObj, columnsMap);

            /*
             * Forma Ampliada de Sorting
             * 
            if (queryObj.SortBy == "age")
                query = queryObj.IsSortAsc ? query.OrderBy(p => p.Age) : query.OrderByDescending(p => p.Age);
            if (queryObj.SortBy == "gender")
                query = queryObj.IsSortAsc ? query.OrderBy(p => p.Gender) : query.OrderByDescending(p => p.Gender);
            if (queryObj.SortBy == "ocupation")
                query = queryObj.IsSortAsc
                    ? query.OrderBy(p => p.Ocupation)
                    : query.OrderByDescending(p => p.Ocupation);
            if (queryObj.SortBy == "address")
                query = queryObj.IsSortAsc ? query.OrderBy(p => p.Address) : query.OrderByDescending(p => p.Address);

            */

            return await query.ToListAsync();
        }

        public async Task AddPhoto(int id, Photo photo)
        {
            var profile = await context.Profiles.SingleOrDefaultAsync(p => p.Id == id);
            profile.Photos.Add(photo);
        }
    }
}