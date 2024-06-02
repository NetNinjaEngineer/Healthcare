namespace Healthcare.Application.Strategies.Reporting;
public sealed class ReportStrategyContext(IReportStrategy strategy)
{
    private IReportStrategy _strategy = strategy;

    public void SetReportStrategy(IReportStrategy strategy)
        => _strategy = strategy;

    public byte[] Report<T>(IEnumerable<T> data)
    {
        return _strategy.Report(data);
    }
}
