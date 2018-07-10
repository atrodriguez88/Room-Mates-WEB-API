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
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly RoomMDbContext context;

        public RoomRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Room> GetRoom(int id)
        {
            return await context.Rooms
                .Include(r => r.PropertyType)
                .Include(r => r.Preference)
                .Include(r => r.Rules)
                .ThenInclude(rpr => rpr.PropertyRules)
                .Include(r => r.PropertyFeatures)
                .ThenInclude(rpf => rpf.PropertyFeatures)
                .Include(r => r.RoomFeatures)
                .ThenInclude(rrf => rrf.RoomFeatures)
                .SingleOrDefaultAsync(x => x.Id == id && x.Deleted == false);
        }

        public async Task<IEnumerable<Room>> GetRooms(RoomQuery queryObj)
        {
            var query = context.Rooms
                .Include(r => r.PropertyType)
                .Include(r => r.Preference)
                .Include(r => r.Rules)
                .ThenInclude(rpr => rpr.PropertyRules)
                .Include(r => r.PropertyFeatures)
                .ThenInclude(rpf => rpf.PropertyFeatures)
                .Include(r => r.RoomFeatures)
                .ThenInclude(rrf => rrf.RoomFeatures)
                .Where(x => x.Deleted == false);

            /*Filters Here*/

            // This filter return a bool is for that I do the else sentence
            if (queryObj.IsFurnished.HasValue && queryObj.IsFurnished == 1)
                query = query.Where(r => r.IsFurnished);
            if (queryObj.IsFurnished.HasValue && queryObj.IsFurnished == 0)
                query = query.Where(r => r.IsFurnished == false);

            if (queryObj.Pet != null)
                query = query.Where(r => r.Pet == queryObj.Pet);

            //  ...

            /* 
               Sorting 
            */

            var columnsMap = new Dictionary<string, Expression<Func<Room, object>>>()
            {
                ["isfurnished"] = room => room.IsFurnished,
                ["pet"] = room => room.Pet
            };

            query = query.ApplySorting(queryObj, columnsMap);

            /*
             * Forma Ampliada de Sorting
             *
            if (queryObj.SortBy.ToLower() == "isfurnished")
                query = queryObj.IsSortAsc
                    ? query.OrderBy(r => r.IsFurnished)
                    : query.OrderByDescending(r => r.IsFurnished);

            if (queryObj.SortBy.ToLower() == "pet")
                query = queryObj.IsSortAsc ? query.OrderBy(r => r.Pet) : query.OrderByDescending(r => r.Pet);

             */


            return await query.ToListAsync();
        }

        public async Task AddPhoto(int id, Photo photo)
        {
            var room = await context.Rooms.SingleOrDefaultAsync(x => x.Id == id);
            room.Photos.Add(photo);
        }
    }
}