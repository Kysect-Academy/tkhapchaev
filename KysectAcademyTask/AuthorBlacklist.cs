namespace KysectAcademyTask;

public class AuthorBlacklist
{
    private readonly List<string> _authors;

    public AuthorBlacklist(List<string> authors)
    {
        _authors = authors;
    }

    public bool Contains(string author)
    {
        foreach (string item in _authors)
        {
            if (item == author)
            {
                return true;
            }
        }

        return false;
    }
}