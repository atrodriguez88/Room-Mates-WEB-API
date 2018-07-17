namespace RoomM.API.Core.QueryString
{
    public class MessageQuery
    {
        public int UserId { get; set; }
        public string MessageSatus { get; set; } = "Unread";

//        public int Id { get; set; }
//        public int SenderMessId { get; set; }
//        public Profile SenderMess { get; set; }
//        public int RecivedMessId { get; set; }
//        public Profile RecivedMess { get; set; }
//        public string Content { get; set; }
//        public bool IsRead { get; set; }
//        public DateTime? DateRead { get; set; }
//        public bool Deleted { get; set; }
    }
}