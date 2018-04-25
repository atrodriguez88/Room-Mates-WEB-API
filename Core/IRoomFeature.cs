using System.Collections.Generic;
using System.Threading.Tasks;
using RoomM.API.Core.Models;

namespace RoomM.API.Core
{
    public interface IRoomFeature
    {
         Task<List<RoomFeatures>> GetRoomFeatures();
    }
}