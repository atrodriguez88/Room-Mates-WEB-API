using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Controllers.Resources
{
    public class ApplicationUserResource
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AdTitle { get; set; }
        public string AdDescription { get; set; }
    }
}