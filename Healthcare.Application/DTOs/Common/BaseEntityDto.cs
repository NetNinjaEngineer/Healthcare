namespace Healthcare.Application.DTOs.Common;

public abstract class BaseEntityDto
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}