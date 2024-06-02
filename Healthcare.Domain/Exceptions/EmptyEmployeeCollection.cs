namespace Healthcare.Domain.Exceptions;
public class EmptyEmployeeCollection : Exception
{
    public EmptyEmployeeCollection(string? message) : base(message)
    {
    }
}
