using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Controllers.Resources
{
    public class ApplicationUserResource
    {
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public bool NotificationViaEmail { get; set; }
        public bool ShowPhone { get; set; }
        public string AboutMe { get; set; }
    }
}