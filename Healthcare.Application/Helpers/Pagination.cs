namespace Healthcare.Application.Helpers;

public class Pagination<T>
{
    public PaginationMetaData PaginationMetaData { get; set; }
    public Pagination(int pageNumber, int pageSize, int totalCount, IReadOnlyList<T> data)
    {
        Data = data;
        PaginationMetaData = new()
        {
            CurrentPage = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize),
        };
    }

    public IReadOnlyList<T> Data { get; set; } = [];
}
