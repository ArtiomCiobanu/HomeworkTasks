using System;
using ConsoleApp1.API.DataSourceAccessers;

namespace ConsoleApp1.API.Static_classes
{
    public static class DataSourceAccesserManager
    {
        public static IDataSourceAccesser GetSaverForSource(string source)
        {
            return source switch
            {
                "Memory" => new MemoryAccesser(),
                "File" => new FileAccesser(),
                "Database" => new DatabaseAccessser(),
                _ => throw new ArgumentException("source should be either Memory, File or Database")
            };
        }
    }
}