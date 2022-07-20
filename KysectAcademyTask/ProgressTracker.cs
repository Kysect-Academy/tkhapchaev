namespace KysectAcademyTask;

public class ProgressTracker
{
    private readonly double _numberOfTasks;

    public ProgressTracker(List<Tuple<string, string, string>> filesToCompare)
    {
        int counter = 0;

        for (int i = 0; i < filesToCompare.Count; ++i)
        {
            for (int j = i + 1; j < filesToCompare.Count; ++j)
            {
                string authorName1 = filesToCompare[i].Item2, authorName2 = filesToCompare[j].Item2;

                if (authorName1 == authorName2)
                {
                    break;
                }

                ++counter;
            }
        }

        _numberOfTasks = counter;
    }

    public void Track(int tasksDone, string taskName)
    {
        double progress = Math.Round((tasksDone / _numberOfTasks * 100), 1);
        Console.Write($"Анализ работ \"{taskName}\": {tasksDone} из {_numberOfTasks} ({progress} %)\n");
    }
}