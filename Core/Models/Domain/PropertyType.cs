using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.API.Core.Models
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