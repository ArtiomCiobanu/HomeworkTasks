using System.Collections.Generic;

namespace DependencyInjection.API.DataSourceAccessers
{
    public interface IDataSourceAccesser
    {
        string GetFileAsString();
        void WriteToFile(string data);
    }
}