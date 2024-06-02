using CsvHelper;
using System.Globalization;

namespace Healthcare.Application.Strategies.Reporting;
public sealed class CSVReportStrategy : IReportStrategy
{
    public byte[] Report<T>(IEnumerable<T> dataToReport)
    {
        using var memoryStream = new MemoryStream();
        using var streamWriter = new StreamWriter(memoryStream);
        using var csvWriter = new CsvWriter(streamWriter, culture: CultureInfo.InvariantCulture);
        csvWriter.WriteRecords(dataToReport);
        streamWriter.Flush();
        return memoryStream.ToArray();
    }
}
