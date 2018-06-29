namespace RoomM.API.Core.Models
{
    public class RoomRoomFeatures
    {
        public int RoomId { get; set; }
        public int RoomFeaturesId { get; set; }
        public Room Room { get; set; }
        public RoomFeatures RoomFeatures { get; set; }
    }
}