using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;
using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Core.Models.Domain
{
    public class Preferences : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        public string PrefGender { get; set; }       

        public int PrefMinAge { get; set; }

        public int PrefMaxAge { get; set; }

        [StringLength(100)]
        public string AdTitle { get; set; }

        [StringLength(255, MinimumLength = 50)]
        public string AdDescription { get; set; }

        public int OcupationId { get; set; }
        public Ocupation PrefOcuppations { get; set; }

        public int RoomId { get; set; }

        public bool Deleted { get; set; }
    }
}
