using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomM.API.Controllers.Resources
{
    public class PreferencesResource
    {
        public int Id { get; set; }

        public string PrefGender { get; set; }

        public int PrefMinAge { get; set; }

        public int PrefMaxAge { get; set; }
        public string AdTitle { get; set; }
        public string AdDescription { get; set; }

        public int OcupationId { get; set; }

        public int RoomId { get; set; }
    }
}
