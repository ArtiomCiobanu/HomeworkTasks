using System.Collections.Generic;
using System.IO;
using DependencyInjection.Models;
using Newtonsoft.Json;

namespace DependencyInjection.API.DataSourceAccessers
{
    public class JsonTaskAccesser : IDataSourceAccesser
    {
        private string FilePath { get; set; }

        public string GetFileAsString()
        {
            var input = File.ReadAllText(FilePath);

            return input;
        }

        public void WriteToFile(string data)
        {
            File.WriteAllText(FilePath, data);
        }


        public JsonTaskAccesser(string filePath)
        {
            SetFilePath(filePath);
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }
    }
}