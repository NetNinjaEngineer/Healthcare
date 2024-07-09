using System.Text.Json.Serialization;

namespace Healthcare.Domain.Enumerations;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ScheduleEnum
{
    Daily,
    DayAfterDay,
    TwiceAWeek,
    Weekend,
    Compact
}
