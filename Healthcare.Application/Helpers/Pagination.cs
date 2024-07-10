namespace Healthcare.Application.Helpers;

public class Pagination<T>
{
    public Pagination(int pageNumber, int pageSize, int totalCount, IReadOnlyList<T> data)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalCount = totalCount;
        Data = data;
    }

    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public IReadOnlyList<T> Data { get; set; } = [];
}
