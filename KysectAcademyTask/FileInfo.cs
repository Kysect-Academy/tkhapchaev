namespace KysectAcademyTask;

public class FileInfo
{
    public string AuthorGroup { get; }

    public string AuthorName { get; }

    public string FileName { get; }

    public FileInfo(string authorGroup, string authorName, string fileName)
    {
        AuthorGroup = authorGroup;
        AuthorName = authorName;
        FileName = fileName;
    }
}