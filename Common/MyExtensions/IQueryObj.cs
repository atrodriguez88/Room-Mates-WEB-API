namespace RoomM.API.Common.MyExtensions
{
    public interface IQueryObj
    {
        string SortBy { get; set; }
        bool IsSortAsc { get; set; }
    }
}