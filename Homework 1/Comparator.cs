namespace Homework1;

public class Comparator
{
    public string CompareFiles(string filePath1, string filePath2)
    {
        string[] firstFileLines = File.ReadAllLines(filePath1);
        string[] secondFileLines = File.ReadAllLines(filePath2);

        var firstFileLen = firstFileLines.Length;
        var secondFileLen = secondFileLines.Length;
        int matchedStrings = 0;

        foreach (var line1 in firstFileLines)
        {
            foreach (var line2 in secondFileLines)
            {
                if (line1 == line2)
                {
                    ++matchedStrings;
                }
            }
        }

        var smallerLength = (firstFileLen >= secondFileLen) ? secondFileLen : firstFileLen;
        var result = (double) matchedStrings / smallerLength;
        return $"{Math.Round(result * 100, 2)} %";
    }
}
