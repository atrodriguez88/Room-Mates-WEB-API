namespace RoomM.API.Core.QueryString
{
    public class FilterProfile
    {
        //        Filtering
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? Ocupation { get; set; }
        public string Address { get; set; }

        //        Sorting
        public string SortBy { get; set; }
        public bool IsSortAsc { get; set; }
    }
}
