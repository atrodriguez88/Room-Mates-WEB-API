using System.Collections.Generic;

namespace RoomM.API.Core.Models
{
    public class RoomFeatures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomRoomFeatures> Room { get; set; }
    }
}