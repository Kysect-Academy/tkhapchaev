using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class JsonParser
{
    private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json").Build();

    public string GetInputDirectoryPath()
    {
        return _configuration["Input directory path"] ?? throw new ArgumentNullException();
    }

    public string GetConsoleOutputStatus()
    {
        return _configuration["Report:Console output:Status"] ?? throw new ArgumentNullException();
    }

    public string GetFileOutputStatus()
    {
        return _configuration["Report:File output:Status"] ?? throw new ArgumentNullException();
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

    public string GetExtensionWhitelist()
    {
        return _configuration["File filters:Extension whitelist"] ?? throw new ArgumentNullException();
    }

    public string GetDirectoryBlacklist()
    {
        return _configuration["File filters:Directory blacklist"] ?? throw new ArgumentNullException();
    }

    public string GetAuthorWhitelist()
    {
        return _configuration["Author filters:Whitelist"] ?? throw new ArgumentNullException();
    }

    public string GetAuthorBlacklist()
    {
        return _configuration["Author filters:Blacklist"] ?? throw new ArgumentNullException();
    }
}