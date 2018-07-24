namespace RoomM.API.Controllers.Resources
{
    public class MessageQueryResource
    {
        public int UserId { get; set; }
        public string MessageSatus { get; set; } = "Unread";
    }
}