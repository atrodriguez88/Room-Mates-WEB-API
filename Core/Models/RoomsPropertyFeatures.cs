namespace RoomM.API.Core.Models
{
    public class RoomsPropertyFeatures
    {
        public int RoomId { get; set; }
        public int PropertyFeaturesId { get; set; }
        public Room Room { get; set; }
        public PropertyFeatures PropertyFeatures { get; set; }
    }
}