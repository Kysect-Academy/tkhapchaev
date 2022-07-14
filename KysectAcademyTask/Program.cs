namespace KysectAcademyTask;

internal class Program
{
    public static void Main()
    {
        var executor = new Executor();

        try
        {
            executor.Compare();
        }
        
        catch (Exception e)
        {
            Console.WriteLine("Кажется, что-то пошло не так...\n" + e.Message);
        }
    }
}