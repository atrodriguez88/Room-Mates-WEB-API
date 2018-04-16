using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.API.Core.Models
{
    [Table("PropertyTypes")]
    public class PropertyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    // Apartment, House, Studio
}