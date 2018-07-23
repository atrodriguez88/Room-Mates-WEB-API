namespace RoomM.API.Core.QueryString
{
    public class MessageQuery
    {
        public int UserId { get; set; }
        public string MessageSatus { get; set; } = "Unread";
    }
}