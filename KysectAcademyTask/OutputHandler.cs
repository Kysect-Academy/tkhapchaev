using System.Text;

namespace KysectAcademyTask;

public class OutputHandler
{
    private readonly JsonConfigurationParser _configurationParser = new();

    private readonly string _reportPath;

    private readonly bool _consoleOutputStatus;

    private readonly bool _fileOutputStatus;

    public OutputHandler()
    {
        _reportPath = _configurationParser.GetReportFilePath() + @"\" + _configurationParser.GetReportFileName() + "." +
                      _configurationParser.GetReportFileType();

        _consoleOutputStatus = _configurationParser.GetConsoleOutputStatus();
        _fileOutputStatus = _configurationParser.GetFileOutputStatus();
    }

    public void WriteToConsole(StringBuilder contents)
    {
        if (_consoleOutputStatus)
        {
            Console.Write(contents);
        }
    }

    public void WriteToFile(StringBuilder contents)
    {
        if (_fileOutputStatus)
        {
            File.AppendAllText(_reportPath, contents.ToString());
        }
    }
}