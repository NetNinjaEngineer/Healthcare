
using Healthcare.Application.Strategies.DataExport.Models;

namespace Healthcare.Application.Strategies.DataExport;
public sealed class PDFExportStrategy : IDataExportStrategy
{
    public void Export(ExportFormat format, string fileName, IEnumerable<object> data)
    {

    }
}
