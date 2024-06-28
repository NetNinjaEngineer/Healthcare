using Healthcare.Domain.ValueObjects;

namespace Healthcare.Domain.Entities;
public class Room : BaseEntity
{
    public string? RoomNumber { get; set; }
    public string? MedicalDepartmentId { get; set; }
    public MedicalDepartment? MedicalDepartment { get; set; }
    public RoomType RoomType { get; set; }
    public AvailabilityStatus AvailabilityStatus { get; set; }
}