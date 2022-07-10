using System;
using System.IO;

namespace Homework1
{
    class Executor
    {
        private JsonParser _parser = new JsonParser();
        
        public string[] GetFileNames()
        {
            var directory = _parser.GetPath();
            string[] files = Directory.GetFiles(directory);
            return files;
        }

        public void Compare()
        {
            try
            {
                var filesToCheck = GetFileNames();
                var resultingFile = _parser.GetResultingFileName();

                for (int i = 0; i < filesToCheck.Length; ++i)
                {
                    for (int j = i + 1; j < filesToCheck.Length; ++j)
                    {
                        string file1 = filesToCheck[i], file2 = filesToCheck[j];
                        var similarityPercentage = new Comparator().CompareFiles(file1, file2);
                        string fileName1 = Path.GetFileName(file1), fileName2 = Path.GetFileName(file2);
                        
                        File.AppendAllText(resultingFile, "Процент схожести файлов ");
                        string result = fileName1 + " и " + fileName2 + " :" + similarityPercentage + "\n";
                        File.AppendAllText(resultingFile, result);
                    }
                }

                File.AppendAllText(resultingFile, "--- " + DateTime.Now + " ---" + "\n");
            }

            catch (Exception failure)
            {
                Console.WriteLine("Кажется, что-то пошло не так...\n" + failure.Message);
            }
        }
    }
}
