using System.Collections.Generic;
using System.Linq;
using DependencyInjection.API.DataSourceAccessers;
using DependencyInjection.Models;
using Newtonsoft.Json;

namespace DependencyInjection.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private IEnumerable<IUserTask> _tasks;

        private IEnumerable<IUserTask> Tasks
        {
            get
            {
                if (SourceHasBeenUpdated || _tasks == null)
                {
                    _tasks = GetDeserializedTasks();
                }

                return _tasks;
            }
        }

        private bool SourceHasBeenUpdated { get; set; }

        private IDataSourceAccesser Accesser { get; }

        public TaskRepository(IDataSourceAccesser accesser)
        {
            SourceHasBeenUpdated = false;
            Accesser = accesser;
        }

        public IEnumerable<IUserTask> GetAllTasks()
        {
            return GetDeserializedTasks();
        }

        public IUserTask GetTaskById(int id)
        {
            return GetDeserializedTasks().First(t => t.Id == id);
        }

        public void UpdateTask(IUserTask task)
        {
            var tasks = GetDeserializedTasks().ToArray();
            tasks[task.Id - 1] = task;

            Accesser.WriteToFile(GetSerializedTasks(tasks));

            SourceHasBeenUpdated = true;
        }

        public void AddTask(IUserTask task)
        {
            var tasks = GetDeserializedTasks().ToList();
            tasks.Add(task);

            SourceHasBeenUpdated = true;
        }

        private IEnumerable<IUserTask> GetDeserializedTasks()
        {
            var input = Accesser.GetFileAsString();

            return JsonConvert.DeserializeObject<IEnumerable<UserTask>>(input);
        }

        private static string GetSerializedTasks(IEnumerable<IUserTask> tasks)
        {
            return JsonConvert.SerializeObject(tasks);
        }
    }
}