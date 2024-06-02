namespace Healthcare.Application.Strategies.Reporting;
public interface IReportStrategy
{
    byte[] Report<T>(IEnumerable<T> dataToReport);
}
