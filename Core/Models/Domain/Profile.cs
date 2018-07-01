using Common.CustomFilters;
using RoomM.API.Core.Models.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Core.Models
{
    public class Profile : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int OcupationId { get; set; }
        public Ocupation Ocupation { get; set; }
        [Required]
        public string Address { get; set; }             // Where do you want to live?
        [Required]
        public string MaxRentMonth { get; set; }        // $/month
        public DateTime MovingDate { get; set; }
        public string Comentarios { get; set; }        // Add a comentars about what you looking for..

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Room> Rooms { get; set; }

        public bool Deleted { get; set; }

        // public Photo Photos { get; set; }

        public Profile()
        {
            Rooms = new Collection<Room>();
        }
    }
}