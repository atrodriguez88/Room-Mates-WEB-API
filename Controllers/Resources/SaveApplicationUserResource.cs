using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Controllers.Resources
{
    public class SaveApplicationUserResource
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
    }
}