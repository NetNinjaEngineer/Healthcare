namespace Healthcare.Domain.Entities;
public class MedicalDepartment : BaseEntity
{
    public string? Name { get; set; }
    public ICollection<Doctor> Doctors { get; set; } = [];
    public ICollection<Nurse> Nurses { get; set; } = [];
    public ICollection<Room> Rooms { get; set; } = [];
}
