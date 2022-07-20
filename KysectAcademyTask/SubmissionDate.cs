namespace KysectAcademyTask;

public class SubmissionDate
{
    public DateTime? ConvertedDate;

    public string? RawDate;

    public void Parse(string date)
    {
        RawDate = date;

        int year = Convert.ToInt32(date.Substring(0, 4)),
            month = Convert.ToInt32(date.Substring(4, 2)),
            day = Convert.ToInt32(date.Substring(6, 2)),
            hours = Convert.ToInt32(date.Substring(8, 2)),
            minutes = Convert.ToInt32(date.Substring(10, 2)),
            seconds = Convert.ToInt32(date.Substring(12, 2));

        ConvertedDate = new DateTime(year, month, day, hours, minutes, seconds);
    }
}