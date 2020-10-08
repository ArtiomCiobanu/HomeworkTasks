using System.Collections.Generic;
using System.IO;
using System.Linq;
using DependencyInjection.API.DataSourceAccessers;
using DependencyInjection.Models;
using Newtonsoft.Json;

namespace DependencyInjection.API.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private IEnumerable<UserTask> _tasks;

        private IEnumerable<UserTask> Tasks
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

        private IDataSourceAccessor Accessor { get; }

        public TaskRepository(IDataSourceAccessor accessor)
        {
            SourceHasBeenUpdated = false;
            Accessor = accessor;
        }

        public IEnumerable<UserTask> GetAll() => Tasks;

        public UserTask GetById(int id)
        {
            return Tasks.First(t => t.Id == id);
        }

        public void Update(UserTask task)
        {
            var tasks = Tasks.ToArray();
            tasks[task.Id - 1] = task;

            Accessor.Write(GetSerializedTasks(tasks));

            SourceHasBeenUpdated = true;
        }

        public void Add(UserTask task)
        {
            var tasks = Tasks.ToList();
            if (tasks.Count > 0)
            {
                task.Id = tasks.Last().Id + 1;
            }
            else
            {
                task.Id = 0;
            }

            tasks.Add(task);

            Accessor.Write(GetSerializedTasks(tasks));

            SourceHasBeenUpdated = true;
        }

        public void Delete(UserTask task)
        {
            var tasks = Tasks.ToList();
            tasks.Remove(task);

            Accessor.Write(GetSerializedTasks(tasks));

            SourceHasBeenUpdated = true;
        }

        public void DeleteById(int id)
        {
            var task = Tasks.First(t => t.Id == id);
            Delete(task);
        }

        private IEnumerable<UserTask> GetDeserializedTasks()
        {
            var input = Accessor.Read();
            return JsonConvert.DeserializeObject<IEnumerable<UserTask>>(input);
        }

        private static string GetSerializedTasks(IEnumerable<UserTask> tasks)
        {
            return JsonConvert.SerializeObject(tasks, Formatting.Indented);
        }
    }
}