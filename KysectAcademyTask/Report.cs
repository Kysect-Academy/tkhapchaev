namespace KysectAcademyTask;

public class Report
{
    public string Path { get; }

    public bool ConsoleOutputStatus { get; }

    public bool FileOutputStatus { get; }

    public Report(string path, bool consoleOutputStatus, bool fileOutputStatus)
    {
        Path = path;
        ConsoleOutputStatus = consoleOutputStatus;
        FileOutputStatus = fileOutputStatus;
    }
}