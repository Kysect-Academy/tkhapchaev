using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class JsonParser
{
    private IConfigurationRoot _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json").Build();

    public string GetPath()
    {
        return _configuration["Working directory:Path"] ?? throw new ArgumentNullException();
    }

    public string GetResultingFileName()
    {
        return _configuration["Resulting file:Name"] ?? throw new ArgumentNullException();
    }
}