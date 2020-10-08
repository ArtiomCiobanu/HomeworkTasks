using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.API.Printers
{
    public interface ITaskPrinter
    {
        void PrintTask(IUserTask userTask);
        void PrintTaskCollection(IEnumerable<IUserTask> taskCollection);
    }
}