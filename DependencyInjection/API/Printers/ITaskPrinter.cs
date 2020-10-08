using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.API.Printers
{
    public interface ITaskPrinter
    {
        void PrintTask(UserTask userTask);
        void PrintTaskCollection(IEnumerable<UserTask> taskCollection);
    }
}