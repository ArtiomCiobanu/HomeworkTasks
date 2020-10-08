using System.Collections.Generic;

namespace DependencyInjection.API.DataSourceAccessers
{
    public interface IDataSourceAccessor
    {
        string Read();
        void Write(string data);
    }
}