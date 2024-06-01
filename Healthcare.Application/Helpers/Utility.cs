using Healthcare.Application.Strategies.DataExport.Models;
using System.Text;

namespace Healthcare.Application.Helpers;
public static class Utility
{
    public static void CreateFile(string fileName, ExportFormat format, string folderName, StringBuilder csvData)
    {
        var uniqueFileName = $"{Guid.NewGuid()}-{fileName}.{format.ToString().ToLower()}";

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot\\{folderName}");

        if (!Directory.Exists(folderPath))
            Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, $"{uniqueFileName}");

        if (File.Exists(filePath))
            File.Delete(filePath);

        File.WriteAllText(filePath, csvData.ToString());
    }
}
