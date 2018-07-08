using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.API.Core.Models.Domain
{
    [Table("Ocupations")]
    public class Ocupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}