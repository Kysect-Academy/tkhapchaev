namespace KysectAcademyTask;

public class Executor
{
    private readonly JsonParser _parser = new();

    private string[] GetInputDirectoryFileNames()
    {
        string directory = _parser.GetInputDirectoryPath();
        string[] files = Directory.GetFiles(directory);
        return files;
    }

    public void Compare()
    {
        string[] filesToCheck = GetInputDirectoryFileNames();
        string report = _parser.GetReportFilePath() + "\\" + _parser.GetReportFileName() + "." +
                        _parser.GetReportFileType();

        for (int i = 0; i < filesToCheck.Length; ++i)
        {
            for (int j = i + 1; j < filesToCheck.Length; ++j)
            {
                string file1 = filesToCheck[i], file2 = filesToCheck[j];
                string fileName1 = Path.GetFileName(file1), fileName2 = Path.GetFileName(file2);
                string similarityPercentage = new Comparator().CompareFiles(file1, file2);

                File.AppendAllText(report, "Процент схожести файлов ");
                string result = fileName1 + " и " + fileName2 + ": " + similarityPercentage + "\n";
                File.AppendAllText(report, result);
            }
        }

        File.AppendAllText(report, "--- " + DateTime.Now + " ---" + "\n\n");
    }
}