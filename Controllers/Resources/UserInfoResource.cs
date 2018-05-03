using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Controllers.Resources
{
    public class UserInfoResource
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