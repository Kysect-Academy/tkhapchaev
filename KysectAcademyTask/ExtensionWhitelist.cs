namespace KysectAcademyTask;

public class ExtensionWhitelist
{
    private readonly List<string> _extensions;

    public ExtensionWhitelist(List<string> extensions)
    {
        _extensions = extensions;
    }

    public bool Contains(string extension)
    {
        foreach (string item in _extensions)
        {
            if ("." + item == extension)
            {
                return true;
            }
        }

        return _extensions.Count == 0;
    }
}