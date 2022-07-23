namespace KysectAcademyTask;

public class Task
{
    public string Name { get; }

    public readonly List<Submission> Submissions = new();

    public Task(string name)
    {
        Name = name;
    }
}