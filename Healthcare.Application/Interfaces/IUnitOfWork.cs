namespace Healthcare.Application.Interfaces;
public interface IUnitOfWork
{
    IEmployeeRepository EmployeeRepository { get; }
    Task CommitAsync();
}
