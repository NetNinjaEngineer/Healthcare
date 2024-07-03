using Healthcare.Domain.Entities;

namespace Healthcare.Application.Interfaces;
public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IPatientRepository PatientRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
    Task<bool> CommitAsync();
}
