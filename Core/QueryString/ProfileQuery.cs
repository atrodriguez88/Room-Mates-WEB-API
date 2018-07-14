using RoomM.API.Common.MyExtensions;

namespace RoomM.API.Core.QueryString
{
    public class ProfileQuery : IQuerySort, IQueryPage
    {
        //        Filtering
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? Ocupation { get; set; }
        public string Address { get; set; }

        //        Sorting

        /*  Create to IQuerySort for clean arquitecture */

        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }

        //        Pagination

        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}
