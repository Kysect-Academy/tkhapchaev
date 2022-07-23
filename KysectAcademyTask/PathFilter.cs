namespace KysectAcademyTask;

public class PathFilter
{
    private readonly JsonConfigurationParser _configurationParser = new();

    public List<List<string>> Filter(List<List<string>> formattedPaths)
    {
        const int pathDepthToFiles = 5;

        var result = formattedPaths.ToList();

        var authorWhitelist = new AuthorWhitelist(_configurationParser.GetAuthorWhitelist());
        var authorBlacklist = new AuthorBlacklist(_configurationParser.GetAuthorBlacklist());
        var extensionWhitelist = new ExtensionWhitelist(_configurationParser.GetExtensionWhitelist());
        var directoryBlacklist = new DirectoryBlacklist(_configurationParser.GetDirectoryBlacklist());

        foreach (List<string> formattedPath in formattedPaths)
        {
            string authorName = formattedPath[1];

            string fileExtension =
                Path.GetExtension(formattedPath.Count == pathDepthToFiles ? formattedPath[4] : formattedPath[3]);

            if (!authorWhitelist.Contains(authorName) || authorBlacklist.Contains(authorName) ||
                !extensionWhitelist.Contains(fileExtension))
            {
                result.Remove(formattedPath);
            }

            foreach (string directory in formattedPath)
            {
                if (directoryBlacklist.Contains(directory))
                {
                    result.Remove(formattedPath);
                }
            }
        }

        return result;
    }
}