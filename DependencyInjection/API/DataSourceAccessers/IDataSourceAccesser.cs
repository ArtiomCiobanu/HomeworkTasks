using System.Collections.Generic;

namespace DependencyInjection.API.DataSourceAccessers
{
    public interface IDataSourceAccesser<Model> where Model : class
    {
        IEnumerable<Model> GetAllRecords();
        
    }
}