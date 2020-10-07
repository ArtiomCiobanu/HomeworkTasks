using System.Collections.Generic;
using DIHomeworkCiobanuArtiom.Models;

namespace DIHomeworkCiobanuArtiom.API.DataSourceAccessers
{
    public interface IDataSourceAccesser<Model> where Model : class
    {
        IEnumerable<Model> GetAllRecords();
        
    }
}