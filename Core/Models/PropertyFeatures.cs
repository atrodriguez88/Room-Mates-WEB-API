using System.Collections.Generic;

namespace RoomM.API.Core.Models
{
    public class PropertyFeatures
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomsPropertyFeatures> Rooms { get; set; }
    }
}