namespace RoomM.API.Core.QueryString
{
    public interface IQueryPage
    {
        //        Pagination

        int Page { get; set; }
        byte PageSize { get; set; }
    }
}