using Healthcare.Application.Strategies.DataExport.Models;

namespace Healthcare.Application.Strategies.DataExport;
public interface IDataExportStrategy
{
    void Export(ExportFormat format, string fileName, IEnumerable<object> data);
}
