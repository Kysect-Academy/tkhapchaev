using System.Text;

namespace KysectAcademyTask;

public class ResultHandler
{
    public StringBuilder Contents { get; }

    public string CurrentTaskName { get; set; }

    private readonly Report _report;

    public ResultHandler(Report report)
    {
        _report = report;
        Contents = new StringBuilder();
    }

    public void WriteToConsole()
    {
        if (_report.ConsoleOutputStatus)
        {
            Console.Write(Contents);
        }
    }

    public void WriteToFile()
    {
        if (_report.FileOutputStatus)
        {
            File.AppendAllText(_report.Path, Contents.ToString());
        }
    }

    public void WriteToFile(StringBuilder source)
    {
        if (_report.FileOutputStatus)
        {
            File.AppendAllText(_report.Path, source.ToString());
        }
    }
}