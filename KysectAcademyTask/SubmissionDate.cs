namespace KysectAcademyTask;

public class SubmissionDate
{
    public DateTime? ConvertedDate;

    public readonly string RawDate;

    public SubmissionDate(string date)
    {
        RawDate = date;
        ConvertedDate = DateTime.ParseExact(date, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
    }
}