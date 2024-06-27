using Healthcare.Domain.Enumerations;
using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;

public class Schedule : BaseEntity
{
    public ScheduleEnum Title { get; set; }
    public TimeSlot TimeSlot { get; set; } = null!;
    public bool SUN { get; set; }
    public bool MON { get; set; }
    public bool TUE { get; set; }
    public bool WED { get; set; }
    public bool THU { get; set; }
    public bool FRI { get; set; }
    public bool SAT { get; set; }
    public ICollection<Employee> Employees { get; set; } = [];
}
