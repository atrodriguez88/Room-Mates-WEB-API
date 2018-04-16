using System.Collections.Generic;

namespace RoomM.API.Core.Models
{
    public class PropertyRules
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<RoomsPropertyRules> Rooms { get; set; }
    }
}