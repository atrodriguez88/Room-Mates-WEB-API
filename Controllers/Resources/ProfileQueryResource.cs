using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Controllers.Resources
{
    public class ProfileQueryResource
    {
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? Ocupation { get; set; }
        public string Address { get; set; }

        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }
    }
}
