﻿using Microsoft.Extensions.Configuration;

namespace KysectAcademyTask;

public class ConfigurationParser
{
    private readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

    public string GetInputDirectoryPath()
    {
        return _configuration.GetSection("Input directory path").Value ?? throw new ArgumentException();
    }

    public IComparator GetComparisonAlgorithm()
    {
        return (_configuration.GetSection("Comparison algorithm").Value ?? throw new ArgumentException()) switch
        {
            "Levenshtein distance" => new LevenshteinDistance(),
            _ => throw new ArgumentException()
        };
    }

    public IWriter GetReportType()
    {
        string reportFilePath = _configuration.GetSection("Report:Path").Value ?? throw new ArgumentException(),
            reportFileName = _configuration.GetSection("Report:Name").Value ?? throw new ArgumentException();

        return (_configuration.GetSection("Report:Type").Value ?? throw new ArgumentException()) switch
        {
            "CMD" => new ConsoleWriter(),
            "TXT" => new TextFileWriter(reportFilePath, reportFileName),
            "JSON" => new JsonWriter(reportFilePath, reportFileName),
            _ => throw new ArgumentException()
        };
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