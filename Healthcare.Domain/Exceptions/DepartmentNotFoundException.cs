namespace Healthcare.Domain.Exceptions;
public class DepartmentNotFoundException : NotFoundException
{
    public DepartmentNotFoundException(string message) : base(message)
    {
    }
}
