using System.Text;

namespace KysectAcademyTask;

public class Analyzer
{
    private readonly JsonConfigurationParser _configurationParser = new();

    private readonly List<Tuple<string, string, string>> _filesToCompare = new();

    private readonly StringBuilder _result = new();

    private readonly OutputHandler _outputHandler = new();

    private void CompareFiles(string taskName, ProgressTracker progressTracker)
    {
        int iterationCounter = 0;

        for (int i = 0; i < _filesToCompare.Count; ++i)
        {
            int counter = 0;

            for (int j = i + 1; j < _filesToCompare.Count; ++j)
            {
                string file1 = _filesToCompare[i].Item3,
                    file2 = _filesToCompare[j].Item3,
                    authorName1 = _filesToCompare[i].Item2,
                    authorName2 = _filesToCompare[j].Item2,
                    groupName1 = _filesToCompare[i].Item1,
                    groupName2 = _filesToCompare[j].Item1,
                    fileName1 = Path.GetFileName(file1),
                    fileName2 = Path.GetFileName(file2);

                if (authorName1 == authorName2)
                {
                    break;
                }

                var comparator = new Comparator();
                var similarityPercentage = new StringBuilder(comparator.CompareFiles(file1, file2));

                var currentComparison = new StringBuilder(
                    $"Задание \"{taskName}\": сравнение {authorName1} ({groupName1}) и " +
                    $"{authorName2} ({groupName2}), файлы {fileName1} и {fileName2} " +
                    $"соответственно: {similarityPercentage}" + "\n");

                _result.Append(currentComparison);
                _outputHandler.WriteToFile(currentComparison);
                ++counter;
            }

            iterationCounter += counter;
            progressTracker.Track(iterationCounter, taskName);
        }

        string separator = "\n" + new string('-', 165) + "\n\n";
        _outputHandler.WriteToFile(new StringBuilder(separator));
        _result.Append(separator);
        _filesToCompare.Clear();
    }

    public void Analyze()
    {
        string inputDirectoryPath = _configurationParser.GetInputDirectoryPath();

        var pathFilter = new PathFilter();
        List<List<string>> formattedPaths = pathFilter.Filter(DirectoryParser.GetFormattedPaths(inputDirectoryPath));

        var authorsHandler = new AuthorHandler(formattedPaths);
        List<Author> authors = authorsHandler.MapAuthorsToTasks();
        authors = authorsHandler.MapSubmissionsToAuthors(authors);

        var taskHandler = new TaskHandler(formattedPaths);
        List<string> tasks = taskHandler.GetAllTaskNames();

        foreach (string taskName in tasks)
        {
            foreach (Author author in authors)
            {
                foreach (Task task in author.Tasks)
                {
                    if (taskName == task.Name)
                    {
                        foreach (Tuple<SubmissionDate, string> file in task.Submissions)
                        {
                            string submission = string.Empty;

                            if (file.Item1.RawDate != null)
                            {
                                submission = file.Item1.RawDate;
                            }

                            string fileName = inputDirectoryPath + @"\" + author.Group + @"\" + author.Name + @"\" +
                                              task.Name + @"\" + submission + @"\" + file.Item2;

                            _filesToCompare.Add(new Tuple<string, string, string>(author.Group, author.Name, fileName));
                        }
                    }
                }
            }

            var progressTracker = new ProgressTracker(_filesToCompare);
            CompareFiles(taskName, progressTracker);
        }

        _outputHandler.WriteToConsole(_result);
    }
}