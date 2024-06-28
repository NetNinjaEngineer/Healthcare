namespace Healthcare.Domain.Entities;

public class LabTest : BaseEntity
{
    public string LabId { get; set; } = null!;
    public Lab Lab { get; set; } = null!;
    public string? TestName { get; set; }
    public string? TestDescription { get; set; }
    public ICollection<LabResult> LabResults { get; set; } = [];
}
