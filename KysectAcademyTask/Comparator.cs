namespace KysectAcademyTask;

public static class Comparator
{
    private static int LevenshteinDistance(string source1, string source2)
    {
        int firstSourceLength = source1.Length, secondSourceLength = source2.Length;
        int[,] matrix = new int[firstSourceLength + 1, secondSourceLength + 1];

        if (firstSourceLength == 0)
        {
            return secondSourceLength;
        }

        if (secondSourceLength == 0)
        {
            return firstSourceLength;
        }

        for (int i = 0; i <= firstSourceLength; matrix[i, 0] = i++) { }

        for (int j = 0; j <= secondSourceLength; matrix[0, j] = j++) { }

        for (int i = 1; i <= firstSourceLength; i++)
        {
            for (int j = 1; j <= secondSourceLength; j++)
            {
                int cost = (source2[j - 1] == source1[i - 1]) ? 0 : 1;
                matrix[i, j] = Math.Min(Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                    matrix[i - 1, j - 1] + cost);
            }
        }

        return matrix[firstSourceLength, secondSourceLength];
    }

    public static double CompareFiles(string filePath1, string filePath2)
    {
        string firstFile = File.ReadAllText(filePath1), secondFile = File.ReadAllText(filePath2);

        int levenshteinDistance = LevenshteinDistance(firstFile, secondFile),
            greaterLength = (firstFile.Length >= secondFile.Length) ? firstFile.Length : secondFile.Length;

        double result = (double) levenshteinDistance / greaterLength;

        return result;
    }
}