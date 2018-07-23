using System;
using RoomM.API.Core.Models.Domain;

namespace RoomM.API.Controllers.Resources
{
    public class SaveMessageResource
    {
        public int SenderMessId { get; set; }
        public int RecivedMessId { get; set; }
        public string Content { get; set; }
        public DateTime DateSend { get; set; }

        public SaveMessageResource()
        {
            DateSend = DateTime.Now;
        }
    }
}