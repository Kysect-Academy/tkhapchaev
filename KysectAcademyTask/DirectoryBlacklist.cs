namespace KysectAcademyTask;

public class DirectoryBlacklist
{
    private readonly List<string> _directories;

    public DirectoryBlacklist(List<string> directories)
    {
        _directories = directories;
    }

    public bool Contains(string directory)
    {
        foreach (string item in _directories)
        {
            if (item == directory)
            {
                return true;
            }
        }

        return false;
    }
}