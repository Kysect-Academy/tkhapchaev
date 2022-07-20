namespace KysectAcademyTask;

public static class Program
{
    public static void Main()
    {
        var analyzer = new Analyzer();

        try
        {
            analyzer.Analyze();
        }

        catch (Exception exception)
        {
            Console.WriteLine("Кажется, что-то пошло не так...\n" + exception.Message);
        }
    }
}