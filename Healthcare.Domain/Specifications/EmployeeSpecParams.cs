using Healthcare.Domain.Enumerations;

namespace Healthcare.Domain.Specifications;

public class EmployeeSpecParams
{
    private int pageSize = 10;
    public string? Sort { get; set; }
    private string? searchTerm;

    public string? SearchTerm
    {
        get { return searchTerm; }
        set { searchTerm = value!.ToLower(); }
    }

    public int PageNumber { get; set; } = 1;

    public int PageSize
    {
        get { return pageSize; }
        set { pageSize = (value > 10) ? pageSize : value; }
    }

    public string? Email { get; set; }
    public Gender? Gender { get; set; }

}
