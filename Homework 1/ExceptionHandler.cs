namespace Homework1;

public class ExceptionHandler
{
    public void Handle(int errorCode)
    {
        if (errorCode == 0)
        {
            return;
        }
        
        if (errorCode == -1)
        {
            Console.WriteLine("Кажется, что-то пошло не так...\n" + "Введённый путь некорректен.");
            return;
        }

        if (errorCode == -2)
        {
            Console.WriteLine("Кажется, что-то пошло не так...\n" + "Отказано в доступе.");
        }
    }
}