namespace KysectAcademyTask;

public class Task
{
    public readonly string Name;

    public readonly List<Tuple<SubmissionDate, string>> Submissions = new List<Tuple<SubmissionDate, string>>();

    public Task(string name)
    {
        Name = name;
    }
}