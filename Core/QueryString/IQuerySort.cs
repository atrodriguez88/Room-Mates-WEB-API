namespace RoomM.API.Core.QueryString
{
    public interface IQuerySort
    {
        string SortBy { get; set; }
        bool IsSortAsc { get; set; }
    }
}