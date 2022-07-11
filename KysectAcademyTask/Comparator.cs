namespace KysectAcademyTask;

public class Comparator
{
    public string CompareFiles(string filePath1, string filePath2)
    {
        string[] firstFileLines = File.ReadAllLines(filePath1);
        string[] secondFileLines = File.ReadAllLines(filePath2);

        int firstFileLen = firstFileLines.Length;
        int secondFileLen = secondFileLines.Length;
        int matchedStrings = 0;

        foreach (string line1 in firstFileLines)
        {
            foreach (string line2 in secondFileLines)
            {
                if (line1 == line2)
                {
                    ++matchedStrings;
                }
            }
        }

        int smallerLength = (firstFileLen >= secondFileLen) ? secondFileLen : firstFileLen;
        double result = (double) matchedStrings / smallerLength;
        return $"{Math.Round(result * 100, 2)} %";
    }
}