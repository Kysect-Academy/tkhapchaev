namespace KysectAcademyTask;

public static class DirectoryParser
{
    private static List<string> Parse(string directoryPath)
    {
        var files = new List<string>();
        string[] subdirectories = Directory.GetDirectories(directoryPath);
        files.AddRange(Directory.GetFiles(directoryPath));

        foreach (string subdirectory in subdirectories)
        {
            files.AddRange(Parse(subdirectory));
        }

        return files;
    }

    public static List<List<string>> GetFormattedPaths(string inputDirectoryPath)
    {
        string inputDirectoryName = Path.GetFileName(inputDirectoryPath);
        List<string> files = Parse(inputDirectoryPath);
        var formattedPaths = new List<string[]>();

        foreach (string file in files)
        {
            formattedPaths.Add(file.Split(@"\"));
        }

        var result = new List<List<string>>();

        var inputDirectoryNamePositions = new List<int>();

        foreach (string[] formattedPath in formattedPaths)
        {
            for (int j = 0; j < formattedPath.Length; ++j)
            {
                if (formattedPath[j] == inputDirectoryName)
                {
                    inputDirectoryNamePositions.Add(j);
                }
            }
        }

        for (int i = 0; i < formattedPaths.Count; ++i)
        {
            var newPath = new List<string>();
            result.Add(newPath);

            for (int j = inputDirectoryNamePositions[i] + 1; j < formattedPaths[i].Length; ++j)
            {
                result[i].Add(formattedPaths[i][j]);
            }
        }

        return result;
    }
}