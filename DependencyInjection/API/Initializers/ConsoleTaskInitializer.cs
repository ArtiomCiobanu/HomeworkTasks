using System;
using Autofac;
using DependencyInjection.Models;

namespace DependencyInjection.API.Initializers
{
    public class ConsoleTaskInitializer : ITaskInitializer
    {
        public UserTask InitializeTask(ILifetimeScope lifetimeScope)
        {
            var userTask = new UserTask();

            Console.WriteLine("Now enter the task data:");
            Console.WriteLine("Enter the title:");
            userTask.Title = Console.ReadLine();
            Console.WriteLine("Enter the content:");
            userTask.Content = Console.ReadLine();

            return userTask;
        }
    }
}