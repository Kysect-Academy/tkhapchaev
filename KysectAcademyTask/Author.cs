namespace KysectAcademyTask;

public class Author
{
    public readonly string Name;

    public readonly string Group;

    public List<Task> Tasks = new List<Task>();

    public Author(string name, string group)
    {
        Name = name;
        Group = group;
    }
}