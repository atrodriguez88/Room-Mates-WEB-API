using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Entity;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetRoom(int id);
        Task<IEnumerable<Room>> GetRooms();
    }
}