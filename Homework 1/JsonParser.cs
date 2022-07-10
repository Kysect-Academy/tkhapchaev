using System.IO;
using Microsoft.Extensions.Configuration;

namespace Homework1
{
    class JsonParser
    {
        private IConfigurationRoot _configuration;

        public string GetPath()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            return _configuration["Working directory:Path"];
        }

        public string GetResultingFileName()
        {
            return _configuration["Resulting file:Name"];
        }
    }
}
