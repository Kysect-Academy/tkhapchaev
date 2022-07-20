namespace KysectAcademyTask;

public class TaskHandler
{
    private readonly List<List<string>> _formattedPaths;

    public TaskHandler(List<List<string>> formattedPaths)
    {
        _formattedPaths = formattedPaths;
    }

    public List<string> GetAllTaskNames()
    {
        var tasks = new HashSet<string>();

        foreach (List<string> formattedPath in _formattedPaths)
        {
            tasks.Add(formattedPath[2]);
        }

        return tasks.ToList();
    }

    public List<string> GetAllTaskNamesForOneGroup(string group)
    {
        var tasks = new HashSet<string>();

        foreach (List<string> formattedPath in _formattedPaths)
        {
            if (group == formattedPath[0])
            {
                tasks.Add(formattedPath[2]);
            }
        }

        return tasks.ToList();
    }
}