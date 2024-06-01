
using Healthcare.Application.Helpers;
using Healthcare.Application.Strategies.DataExport.Models;
using System.Text;

namespace Healthcare.Application.Strategies.DataExport;
public sealed class CSVExportStrategy : IDataExportStrategy
{
    public void Export(ExportFormat format, string fileName, IEnumerable<object> data)
    {
        StringBuilder csvData = new();
        if (data is not null)
        {
            var properties = data.First().GetType().GetProperties();
            csvData.AppendLine(string.Join(",", properties.Select(p => p.Name)));
            foreach (var item in data)
            {
                var values = item.GetType().GetProperties().Select(p => p.GetValue(item));
                csvData.AppendLine(string.Join(",", values.Select(v => v?.ToString() ?? "")));
            }

            Utility.CreateFile(fileName, format, Constants.FilesFolderName, csvData);
        }


    }
}
