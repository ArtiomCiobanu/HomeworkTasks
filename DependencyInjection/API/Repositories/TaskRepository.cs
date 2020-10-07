using System.Collections.Generic;
using DependencyInjection.API.DataSourceAccessers;
using DependencyInjection.Models;

namespace DependencyInjection.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private IDataSourceAccesser<UserTask> Accesser { get; }

        public TaskRepository(IDataSourceAccesser<UserTask> accesser)
        {
            Accesser = accesser;
        }

        public IEnumerable<UserTask> GetAllTasks()
        {
            return Accesser.GetAllRecords();
        }

        public UserTask GetTaskById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateTask(UserTask task)
        {
            throw new System.NotImplementedException();
        }

        public void AddTask(UserTask task)
        {
            throw new System.NotImplementedException();
        }
    }
}