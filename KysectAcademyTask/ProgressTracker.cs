namespace KysectAcademyTask;

public class ProgressTracker
{
    private readonly double _numberOfTasks;

    public ProgressTracker(List<FileInfo> filesToCompare)
    {
        int iterationCounter = 0;

        for (int i = 0; i < filesToCompare.Count; ++i)
        {
            for (int j = i + 1; j < filesToCompare.Count; ++j)
            {
                string authorName1 = filesToCompare[i].AuthorName, authorName2 = filesToCompare[j].AuthorName;

                if (authorName1 == authorName2)
                {
                    break;
                }

                ++iterationCounter;
            }
        }

        _numberOfTasks = iterationCounter;
    }

    public void Track(int tasksDone, string taskName)
    {
        double progress = Math.Round((tasksDone / _numberOfTasks * 100), 1);
        Console.Write($"Анализ работ \"{taskName}\": {tasksDone} из {_numberOfTasks} ({progress} %)\n");
    }
}