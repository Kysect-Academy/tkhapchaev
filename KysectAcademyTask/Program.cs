namespace KysectAcademyTask;

public class Program
{
    public static void Main()
    {
        var executor = new Executor();

        try
        {
            executor.Compare();
        }

        catch (Exception exception)
        {
            Console.WriteLine("Кажется, что-то пошло не так...\n" + exception.Message);
        }
    }
}