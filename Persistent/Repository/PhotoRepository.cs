using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.Repository;
using RoomM.API.Persistent.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Persistent.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        private readonly RoomMDbContext context;
        public PhotoRepository(RoomMDbContext context) : base(context)
        {
            this.context = context;

        }
    }
}
