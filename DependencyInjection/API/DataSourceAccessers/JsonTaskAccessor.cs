using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using DependencyInjection.Models;
using Newtonsoft.Json;

namespace DependencyInjection.API.DataSourceAccessers
{
    public class JsonTaskAccessor : IDataSourceAccessor
    {
        private string FilePath { get; set; }

        public string Read()
        {
            try
            {
                return File.ReadAllText(FilePath);
            }
            catch (FileNotFoundException)
            {
                File.Create(FilePath).Dispose();
                return "[]";
            }
        }

        public void Write(string data)
        {
            File.WriteAllText(FilePath, data);
        }


        public JsonTaskAccessor(string filePath)
        {
            SetFilePath(filePath);
        }

        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
        }
    }
}