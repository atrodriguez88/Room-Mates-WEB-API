using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;

namespace RoomM.API.Core.Repository
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetRoom(int id);
        Task<IEnumerable<Room>> GetRooms(RoomQuery queryObj);
        Task AddPhoto(int id, Photo photo);
    }
}