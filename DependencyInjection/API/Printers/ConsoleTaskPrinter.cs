using System;
using System.Collections.Generic;
using DependencyInjection.Models;

namespace DependencyInjection.API.Printers
{
    public class ConsoleTaskPrinter : ITaskPrinter
    {
        public void PrintTask(UserTask userTask)
        {
            Console.WriteLine();
            Console.WriteLine($"{userTask.Title}:");
            Console.WriteLine(userTask.Content);
        }

        public void PrintTaskCollection(IEnumerable<UserTask> taskCollection)
        {
            foreach (var userTask in taskCollection)
            {
                PrintTask(userTask);
            }
        }
    }
}