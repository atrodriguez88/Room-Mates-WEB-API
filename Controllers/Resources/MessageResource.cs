using System;
using RoomM.API.Core.Models.Domain;

namespace RoomM.API.Controllers.Resources
{
    public class MessageResource
    {
        public int SenderMessId { get; set; }
        public int RecivedMessId { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
    }
}