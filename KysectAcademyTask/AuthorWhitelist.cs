namespace KysectAcademyTask;

public class AuthorWhitelist
{
    private readonly List<string> _authors;

    public AuthorWhitelist(List<string> authors)
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

        return _authors.Count == 0;
    }
}