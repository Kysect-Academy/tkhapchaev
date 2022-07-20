namespace KysectAcademyTask;

public class AuthorHandler
{
    private readonly List<List<string>> _formattedPaths;

    public AuthorHandler(List<List<string>> formattedPaths)
    {
        _formattedPaths = formattedPaths;
    }

    public List<Author> MapAuthorsToTasks()
    {
        var authors = new List<Author>();
        var parsedAuthors = new List<string>();

        foreach (List<string> path in _formattedPaths)
        {
            string authorName = path[1];
            string authorGroup = path[0];
            bool isUnique = true;

            foreach (string parsedAuthor in parsedAuthors)
            {
                if (authorName == parsedAuthor)
                {
                    isUnique = false;
                }
            }

            if (isUnique)
            {
                parsedAuthors.Add(path[1]);
                var author = new Author(authorName, authorGroup);
                authors.Add(author);
            }
        }

        foreach (List<string> path in _formattedPaths)
        {
            string authorName = path[1];
            string taskName = path[2];

            foreach (Author author in authors)
            {
                if (authorName == author.Name)
                {
                    bool isUnique = true;

                    foreach (Task task in author.Tasks)
                    {
                        if (task.Name == taskName)
                        {
                            isUnique = false;
                        }
                    }

                    if (isUnique)
                    {
                        author.Tasks.Add(new Task(taskName));
                    }
                }
            }
        }

        return authors;
    }

    public List<Author> MapSubmissionsToAuthors(List<Author> authors)
    {
        var tasksLinkedToAuthors = new Dictionary<string, List<Task>>();
        const int pathDepthToFiles = 5;

        foreach (Author author in authors)
        {
            tasksLinkedToAuthors.Add(author.Name, author.Tasks);
        }

        foreach (List<string> path in _formattedPaths)
        {
            string authorName = path[1], taskName = path[2], file;
            var submissionDate = new SubmissionDate();
            List<Task> tasks = tasksLinkedToAuthors[authorName];

            if (path.Count == pathDepthToFiles)
            {
                submissionDate.Parse(path[3]);
                file = path[4];
            }

            else
            {
                submissionDate.ConvertedDate = null;
                file = path[3];
            }

            foreach (Task task in tasks)
            {
                if (taskName == task.Name)
                {
                    task.Submissions.Add(new Tuple<SubmissionDate, string>(submissionDate, file));
                }
            }

            foreach (Author author in authors)
            {
                if (authorName == author.Name)
                {
                    author.Tasks = tasks;
                }
            }
        }

        return authors;
    }
}