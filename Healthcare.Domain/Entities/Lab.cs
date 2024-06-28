namespace Healthcare.Domain.Entities;
public class Lab : BaseEntity
{
    public string? LabName { get; set; }
    public string? Location { get; set; }
    public ICollection<LabTest> LabTests { get; set; } = [];
}