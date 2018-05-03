using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Core.Models
{
    public class UserInfo
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string adTitle { get; set; }
        public string adDescription { get; set; }
    }
}