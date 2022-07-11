namespace Homework1;

internal class Program
{
    public static void Main()
    {
        Executor executor = new Executor();
        ExceptionHandler handler = new ExceptionHandler();
        
        var returnCode = executor.Compare();
        handler.Handle(returnCode);
    }
}
