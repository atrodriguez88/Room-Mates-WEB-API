using System;
using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Core.Models
{
    public class Profile
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
        public string Comentarios { get; set; }         // Add a comentars about what you looking for..
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        // public Photo Photos { get; set; }
    }
}