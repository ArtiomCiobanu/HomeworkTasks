using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.API.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<UserTask> GetAllTasks();
        UserTask GetTaskById(int id);
        void UpdateTask(UserTask task);
        void AddTask(UserTask task);
    }
}