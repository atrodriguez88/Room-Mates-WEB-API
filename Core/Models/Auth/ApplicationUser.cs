using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace RoomM.API.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public bool ShowPhone { get; set; }
        
        public bool NotificationViaEmail { get; set; }
        [StringLength(255)]
        public string AboutMe { get; set; }
        public string Address { get; set; }

        public int ProfilesId { get; set; }

        [NotMapped]
        public Profile Profiles { get; set; }

        // public string Photo { get; set; }               // Change

        // [Required]
        // [StringLength(50)]
        // public string AdvertizeAs { get; set; }
    }
}