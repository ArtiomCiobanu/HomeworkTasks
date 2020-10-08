using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.API.Repositories
{
    public interface ITaskRepository
    {
        IEnumerable<IUserTask> GetAllTasks();
        IUserTask GetTaskById(int id);
        void UpdateTask(IUserTask task);
        void AddTask(IUserTask task);
    }
}