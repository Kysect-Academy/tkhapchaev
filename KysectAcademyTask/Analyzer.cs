using System.Text;

namespace KysectAcademyTask;

public class Analyzer
{
    private readonly string _inputDirectoryPath;

    private readonly string _reportFilePath;

    private readonly string _reportFileName;

    private readonly string _reportFileType;

    private readonly bool _consoleOutputStatus;

    private readonly bool _fileOutputStatus;

    public Analyzer(string inputDirectoryPath, string reportFilePath, string reportFileName, string reportFileType,
        bool consoleOutputStatus, bool fileOutputStatus)
    {
        _inputDirectoryPath = inputDirectoryPath;
        _reportFilePath = reportFilePath;
        _reportFileName = reportFileName;
        _reportFileType = reportFileType;
        _consoleOutputStatus = consoleOutputStatus;
        _fileOutputStatus = fileOutputStatus;
    }

    public void Analyze()
    {
        List<FileInfo> filesToCompare = new();
        string reportFullPath = _reportFilePath + @"\" + _reportFileName + "." + _reportFileType;
        var report = new Report(reportFullPath, _consoleOutputStatus, _fileOutputStatus);

        var pathFilter = new PathFilter();
        List<List<string>> formattedPaths = pathFilter.Filter(DirectoryParser.GetFormattedPaths(_inputDirectoryPath));

        var authorsHandler = new AuthorHandler(formattedPaths);
        List<Author> authors = authorsHandler.MapAuthorsToTasks();
        authors = authorsHandler.MapSubmissionsToAuthors(authors);

        var taskHandler = new TaskHandler(formattedPaths);
        List<string> tasks = taskHandler.GetAllTaskNames();
        var resultHandler = new ResultHandler(report);

        foreach (string taskName in tasks)
        {
            resultHandler.CurrentTaskName = taskName;

            foreach (Author author in authors)
            {
                CompareAuthorTasks(author, filesToCompare, resultHandler);
            }

            var progressTracker = new ProgressTracker(filesToCompare);
            CompareFiles(filesToCompare, progressTracker, resultHandler);
        }

        resultHandler.WriteToConsole();
    }

    private void CompareAuthorTasks(Author author, List<FileInfo> filesToCompare, ResultHandler resultHandler)
    {
        foreach (Task task in author.Tasks)
        {
            if (resultHandler.CurrentTaskName == task.Name)
            {
                foreach (Submission file in task.Submissions)
                {
                    string submission = string.Empty;

                    if (file.SubmissionDate.RawDate != null)
                    {
                        submission = file.SubmissionDate.RawDate;
                    }

                    string fileName = _inputDirectoryPath + @"\" + author.Group + @"\" + author.Name + @"\" +
                                      task.Name + @"\" + submission + @"\" + file.FileName;

                    filesToCompare.Add(new FileInfo(author.Group, author.Name, fileName));
                }
            }
        }
    }

    private void CompareFiles(List<FileInfo> filesToCompare, ProgressTracker progressTracker,
        ResultHandler resultHandler)
    {
        int iterationCounter = 0;
        string taskName = resultHandler.CurrentTaskName;

        for (int i = 0; i < filesToCompare.Count; ++i)
        {
            int counter = 0;

            for (int j = i + 1; j < filesToCompare.Count; ++j)
            {
                string file1 = filesToCompare[i].FileName,
                    file2 = filesToCompare[j].FileName,
                    authorName1 = filesToCompare[i].AuthorName,
                    authorName2 = filesToCompare[j].AuthorName,
                    groupName1 = filesToCompare[i].AuthorGroup,
                    groupName2 = filesToCompare[j].AuthorGroup,
                    fileName1 = Path.GetFileName(file1),
                    fileName2 = Path.GetFileName(file2);

                if (authorName1 == authorName2)
                {
                    break;
                }

                var similarityPercentage =
                    new StringBuilder($"{Math.Round(100 - (Comparator.CompareFiles(file1, file2) * 100), 2)} %");

                var currentComparison = new StringBuilder(
                    $"Задание \"{taskName}\": сравнение {authorName1} ({groupName1}) и " +
                    $"{authorName2} ({groupName2}), файлы {fileName1} и {fileName2} " +
                    $"соответственно: {similarityPercentage}" + "\n");

                resultHandler.Contents.Append(currentComparison);
                resultHandler.WriteToFile();
                ++counter;
            }

            iterationCounter += counter;
            progressTracker.Track(iterationCounter, taskName);
        }

        string separator = "\n" + new string('-', 165) + "\n\n";
        resultHandler.WriteToFile(new StringBuilder(separator));
        resultHandler.Contents.Append(separator);
        filesToCompare.Clear();
    }
}