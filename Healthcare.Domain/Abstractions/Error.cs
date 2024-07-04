using System.Text.Json;

namespace Healthcare.Domain.Abstractions;
public record Error(string Code, string? Description = null)
{
    public static readonly Error None = new(string.Empty);

    public override string ToString() => JsonSerializer.Serialize(this);
}
