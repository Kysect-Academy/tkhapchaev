namespace KysectAcademyTask;

public class Submission
{
    public SubmissionDate SubmissionDate { get; }

    public string FileName { get; }

    public Submission(SubmissionDate submissionDate, string fileName)
    {
        SubmissionDate = submissionDate;
        FileName = fileName;
    }
}