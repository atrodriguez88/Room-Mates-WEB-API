using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;

namespace RoomM.API.Core.Models.Domain
{
    public class Message : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public int SenderMessId { get; set; }
        public Profile SenderMess { get; set; }
        public int RecivedMessId { get; set; }
        public Profile RecivedMess { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public bool Deleted { get; set; }
    }
}