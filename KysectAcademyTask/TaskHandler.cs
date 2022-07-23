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

        foreach (string currentTaskName in _formattedPaths.Select(formattedPath => formattedPath[2]))
        {
            tasks.Add(currentTaskName);
        }

        return tasks.ToList();
    }

    public List<string> GetAllTaskNamesForOneGroup(string group)
    {
        var tasks = new HashSet<string>();

        foreach (List<string> formattedPath in _formattedPaths)
        {
            string currentTaskName = formattedPath[2], currentGroupName = formattedPath[0];

            if (group == currentGroupName)
            {
                tasks.Add(currentTaskName);
            }
        }

        return tasks.ToList();
    }
}