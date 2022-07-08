using System.IO;
using Microsoft.Extensions.Configuration;

namespace Homework1
{
    class JsonParser
    {
        private static IConfigurationRoot _configuration;

        public static string GetPath()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            return _configuration["Working directory:Path"];
        }

        public static string GetResultingFileName()
        {
            return _configuration["Resulting file:Name"];
        }
    }
}