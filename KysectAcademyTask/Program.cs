namespace KysectAcademyTask;

public static class Program
{
    public static void Main()
    {
        try
        {
            var jsonConfigurationParser = new JsonConfigurationParser();

            var analyzer = new Analyzer(jsonConfigurationParser.GetInputDirectoryPath(),
                jsonConfigurationParser.GetReportFilePath(), jsonConfigurationParser.GetReportFileName(),
                jsonConfigurationParser.GetReportFileType(),
                jsonConfigurationParser.GetConsoleOutputStatus(), jsonConfigurationParser.GetFileOutputStatus());


            analyzer.Analyze();
        }

        catch (Exception exception)
        {
            Console.WriteLine("Кажется, что-то пошло не так...\n" + exception.Message);
        }
    }
}