using System.ComponentModel.DataAnnotations.Schema;
using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;

namespace RoomM.API.Core.Models.Domain
{
    [Table("PropertyTypes")]
    public class PropertyType : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
    }
    // Apartment, House, Studio
}