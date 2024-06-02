using System.Text.Json.Serialization;

namespace Healthcare.Application.Strategies.Reporting;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ExportType
{
    PDF = 1,
    CSV
}
