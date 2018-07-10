using RoomM.API.Common.MyExtensions;

namespace RoomM.API.Core.QueryString
{
    public class ProfileQuery : IQueryObj
    {
        //        Filtering
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? Ocupation { get; set; }
        public string Address { get; set; }

        //        Sorting

        /*  Create to IQueryObj for clean arquitecture */

        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }
    }
}
