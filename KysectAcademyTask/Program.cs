namespace KysectAcademyTask;

internal class Program
{
    public static void Main()
    {
        var executor = new Executor();
        var handler = new ExceptionHandler();

        int returnCode = executor.Compare();
        handler.Handle(returnCode);
    }
}