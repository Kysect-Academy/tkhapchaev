namespace KysectAcademyTask;

public class Author
{
    public string Name { get; }

    public string Group { get; }

    public List<Task> Tasks = new();

    public Author(string name, string group)
    {
        Name = name;
        Group = group;
    }
}