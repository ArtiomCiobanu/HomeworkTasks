using System.Collections.Generic;
using DIHomeworkCiobanuArtiom.Models;

namespace DIHomeworkCiobanuArtiom.API.DataSourceAccessers
{
    public class JsonAccesser : IDataSourceAccesser<UserTask>
    {
        private string _filePath;
        public string FilePath => _filePath;

        public IEnumerable<UserTask> GetAllRecords()
        {
            throw new System.NotImplementedException();
        }

        public JsonAccesser()
        {
        }

        public JsonAccesser(string filePath)
        {
            SetFilePath(filePath);
        }

        public void SetFilePath(string filePath)
        {
            _filePath = filePath;
        }
    }
}