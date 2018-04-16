using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace RoomM.API.Core.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Address { get; set; }
        /* ************* About Property ************* */
        public int PropertyId { get; set; }
        public PropertyType PropertyType { get; set; }
        [Required]
        public int NumberBedrooms { get; set; }
        public int NumberBathrooms { get; set; }
        public int RoomsToRent { get; set; }
        public ICollection<RoomsPropertyFeatures> PropertyFeatures { get; set; }
        public ICollection<RoomsPropertyRules> Rules { get; set; }

        /* ************ About Room ***************** */
        [Required]
        public float RentPerMonth { get; set; }
        public bool IsUtilityIncluded { get; set; }     // En caso ke si add "Utility costs per month ($)"
        [Required]
        [StringLength(50)]
        public string RoomType { get; set; }            // Single Room, Double, Shared
        public float RoomSquareMeters { get; set; }
        [Required]
        public bool IsFurnished { get; set; }
        public ICollection<RoomRoomFeatures> RoomFeatures { get; set; }
        public DateTime AvailableFrom { get; set; }
        public int MinStayMonths { get; set; }

        public int PrefMaxAge { get; set; }
        public string Smoking { get; set; }
        public string Pet { get; set; }             // Dog(s) ok, Cat(s) ok, Caged Pet(s) ok,
        public string Cleanliness { get; set; }     // Clean, Average, Messy
        /* ************ Current Roommates ***************** */
        public int NumberRoomatesAlready { get; set; }

        /* ************ Preferred Roommates ***************** */
        public string PrefGender { get; set; }
        public int OcupationId { get; set; }
        public Ocupation PrefOcuppations { get; set; }
        public int PrefMinAge { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
        // public Photo Photos { get; set; }
        public Room()
        {
            Rules = new Collection<RoomsPropertyRules>();
            PropertyFeatures = new Collection<RoomsPropertyFeatures>();
            RoomFeatures = new Collection<RoomRoomFeatures>();
        }

    }
}