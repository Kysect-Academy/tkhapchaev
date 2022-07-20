using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class JsonConfigurationParser
{
    private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    public string GetInputDirectoryPath()
    {
        return _configuration["Input directory path"] ?? throw new ArgumentNullException();
    }

    public bool GetConsoleOutputStatus()
    {
        bool result = _configuration.GetSection("Report:Console output:Status").Get<bool>();
        return result;
    }

    public bool GetFileOutputStatus()
    {
        bool result = _configuration.GetSection("Report:File output:Status").Get<bool>();
        return result;
    }

    public string GetReportFilePath()
    {
        return _configuration["Report:File output:Path"] ?? throw new ArgumentNullException();
    }

    public string GetReportFileName()
    {
        return _configuration["Report:File output:Name"] ?? throw new ArgumentNullException();
    }

    public string GetReportFileType()
    {
        return _configuration["Report:File output:Type"] ?? throw new ArgumentNullException();
    }

    public List<string> GetExtensionWhitelist()
    {
        List<string> result = _configuration.GetSection("File filters:Extension whitelist").Get<List<string>>()!;
        return result ?? new List<string>();
    }

    public List<string> GetDirectoryBlacklist()
    {
        List<string> result = _configuration.GetSection("File filters:Directory blacklist").Get<List<string>>()!;
        return result ?? new List<string>();
    }

    public List<string> GetAuthorWhitelist()
    {
        List<string> result = _configuration.GetSection("Author filters:Whitelist").Get<List<string>>()!;
        return result ?? new List<string>();
    }

    public List<string> GetAuthorBlacklist()
    {
        List<string> result = _configuration.GetSection("Author filters:Blacklist").Get<List<string>>()!;
        return result ?? new List<string>();
    }
}