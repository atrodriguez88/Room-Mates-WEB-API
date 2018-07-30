using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Common.CustomFilters;
using RoomM.API.Core.Models.Auth;
using RoomM.API.Core.Models.Helper;

namespace RoomM.API.Core.Models.Domain
{
    public class Profile : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        [Required]
        public int NickName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Gender { get; set; }

        public int OcupationId { get; set; }
        public Ocupation Ocupation { get; set; }
        [Required]
        public string Address { get; set; }             // Where do you want to live?
        [Required]
        public string MaxRentMonth { get; set; }        // $/month
        [Required]
        public DateTime MovingDate { get; set; }
        public string Comentarios { get; set; }        // Add a comentars about what you looking for..

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public bool Deleted { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Message> MessagesSender { get; set; }
        public ICollection<Message> MessagesRecived { get; set; }

        public Profile()
        {
            Photos = new Collection<Photo>();
            MessagesSender = new Collection<Message>();
            MessagesRecived = new Collection<Message>();
        }
    }
}