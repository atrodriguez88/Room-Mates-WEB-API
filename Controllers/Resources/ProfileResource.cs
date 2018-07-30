using System;

namespace RoomM.API.Controllers.Resources
{
    public class ProfileResource
    {
        public int Id { get; set; }
        public int NickName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        // public int OcupationId { get; set; }
        public KeyValuePairResource Ocupation { get; set; }
        public string Address { get; set; }  
        public string MaxRentMonth { get; set; }
        public DateTime MovingDate { get; set; }
        public string Comentarios { get; set; }
        public int UserId { get; set; }
        // public ApplicationUser User { get; set; }
    }
}