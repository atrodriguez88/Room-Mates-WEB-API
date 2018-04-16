using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RoomM.API.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]

        [StringLength(50)]
        public string LastName { get; set; }
        public bool ShowPhone { get; set; }
        [Required]
        [StringLength(100)]
        public string AdTitle { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 50)]
        public string AdDescription { get; set; }
        public bool NotificationViaEmail { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Profile> Profiles { get; set; }

        // public string Photo { get; set; }               // Change

        // [Required]
        // [StringLength(50)]
        // public string AdvertizeAs { get; set; }
        public ApplicationUser()
        {
            Rooms = new Collection<Room>();
            Profiles = new Collection<Profile>();
        }
    }
}