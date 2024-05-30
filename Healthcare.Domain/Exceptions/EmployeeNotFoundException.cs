namespace Healthcare.Domain.Exceptions
{
    [Serializable]
    public class EmployeeNotFoundException(string? message) : NotFoundException(message);
}