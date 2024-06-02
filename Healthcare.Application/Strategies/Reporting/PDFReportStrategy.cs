
using DinkToPdf;
using DinkToPdf.Contracts;
using System.Reflection;
using System.Text;

namespace Healthcare.Application.Strategies.Reporting;
public sealed class PDFReportStrategy(IConverter converter) : IReportStrategy
{
    private readonly IConverter _converter = converter;

    public byte[] Report<T>(IEnumerable<T> dataToReport)
    {
        StringBuilder sb = new();
        sb.Append(@"
            <!DOCTYPE html>
            <html lang=""en"">
            <head>
                <meta charset=""UTF-8"">
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <title>Employee List</title>
                <style>
                    body {
                        font-family: Arial, sans-serif;
                        margin: 40px;
                    }
                    h1 {
                        text-align: center;
                    }
                    table {
                        width: 100%;
                        border-collapse: collapse;
                        margin-top: 20px;
                    }
                    table, th, td {
                        border: 1px solid black;
                    }
                    th, td {
                        padding: 15px;
                        text-align: left;
                    }
                    th {
                        background-color: #f2f2f2;
                    }
                </style>
            </head>
            <body>
                <h1>Employee List</h1>
                <table>");

        sb.Append("<tr>");
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
            sb.Append($"<th>{property.Name}</th>");
        sb.Append("</tr>");

        foreach (var item in dataToReport)
        {
            sb.Append("<tr>");
            foreach (var property in properties)
            {
                var propValue = property.GetValue(item);
                sb.Append($"<td>{propValue}</td>");
            }
            sb.Append("</tr>");
        }

        sb.Append("</table></body></html>");

        var document = new HtmlToPdfDocument
        {
            GlobalSettings = new()
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4
            },
            Objects =
            {
                new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = sb.ToString()
                }
            }
        };

        return _converter.Convert(document);
    }
}
