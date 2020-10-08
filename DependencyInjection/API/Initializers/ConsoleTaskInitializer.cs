using System;
using Autofac;
using DependencyInjection.Models;

namespace DependencyInjection.API.Initializers
{
    public class ConsoleTaskInitializer : ITaskInitializer
    {
        public IUserTask InitializeTask(ILifetimeScope lifetimeScope)
        {
            var userTask = lifetimeScope.Resolve<IUserTask>();

            Console.WriteLine("Now enter the task data:");
            Console.WriteLine("Enter the title:");
            userTask.Title = Console.ReadLine();
            Console.WriteLine("Enter the content:");
            userTask.Content = Console.ReadLine();

            return userTask;
        }
    }
}