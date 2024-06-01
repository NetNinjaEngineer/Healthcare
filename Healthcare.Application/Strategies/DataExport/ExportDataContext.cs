using Healthcare.Application.Strategies.DataExport.Models;

namespace Healthcare.Application.Strategies.DataExport;
public sealed class ExportDataContext
{
    private IDataExportStrategy _strategy;

    public ExportDataContext(IDataExportStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IDataExportStrategy strategy) => _strategy = strategy;

    public void ExportData(ExportFormat format, string fileName, IEnumerable<object> data)
    {
        _strategy.Export(format, fileName, data);
    }

}
