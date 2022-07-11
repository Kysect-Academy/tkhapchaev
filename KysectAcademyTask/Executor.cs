using System.Security;

namespace KysectAcademyTask;

public class Executor
{
    private JsonParser _parser = new();

    public string[] GetFileNames()
    {
        string directory = _parser.GetPath();
        string[] files = Directory.GetFiles(directory);
        return files;
    }

    public int Compare()
    {
        try
        {
            string[] filesToCheck = GetFileNames();
            string resultingFile = _parser.GetResultingFileName();

            for (int i = 0; i < filesToCheck.Length; ++i)
            {
                for (int j = i + 1; j < filesToCheck.Length; ++j)
                {
                    string file1 = filesToCheck[i], file2 = filesToCheck[j];
                    string similarityPercentage = new Comparator().CompareFiles(file1, file2);
                    string fileName1 = Path.GetFileName(file1), fileName2 = Path.GetFileName(file2);

                    File.AppendAllText(resultingFile, "Процент схожести файлов ");
                    string result = fileName1 + " и " + fileName2 + ": " + similarityPercentage + "\n";
                    File.AppendAllText(resultingFile, result);
                }
            }

            File.AppendAllText(resultingFile, "--- " + DateTime.Now + " ---" + "\n\n");
            return 0;
        }

        catch (Exception failure)
        {
            if (failure is UnauthorizedAccessException || failure is SecurityException)
            {
                return -2;
            }

            return -1;
        }
    }
}