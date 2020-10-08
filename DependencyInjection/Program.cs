using System;
using System.IO;
using System.Linq;
using Autofac;
using DependencyInjection.API.DataSourceAccessers;
using DependencyInjection.API.Initializers;
using DependencyInjection.API.Printers;
using DependencyInjection.API.Repositories;
using DependencyInjection.Models;

namespace DependencyInjection
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            //var path = @"UserTasks.json";
            var path = @"C:\UserTasks.json";

            var builder = new ContainerBuilder();

            builder.Register(ja => new JsonTaskAccessor(path))
                .As<IDataSourceAccessor>();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>().SingleInstance();
            builder.RegisterType<ConsoleTaskPrinter>().As<ITaskPrinter>().SingleInstance();
            builder.RegisterType<ConsoleTaskInitializer>().As<ITaskInitializer>().SingleInstance();

            var container = builder.Build();

            using (var lifetime = container.BeginLifetimeScope())
            {
                var taskPrinter = lifetime.Resolve<ITaskPrinter>();
                var taskRepository = lifetime.Resolve<ITaskRepository>();
                var taskInitializer = lifetime.Resolve<ITaskInitializer>();

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose the action:");
                    Console.WriteLine("1 - Print all the tasks");
                    Console.WriteLine("2 - Print a task with specific id");
                    Console.WriteLine("3 - Update a task");
                    Console.WriteLine("4 - Delete a task");
                    Console.WriteLine("5 - Add a new task");
                    Console.WriteLine("6 - to close the app");
                    Console.WriteLine("Now enter the action:");

                    var action = int.Parse(Console.ReadLine()!);

                    if (action == 6)
                    {
                        break;
                    }

                    int id = 0;
                    UserTask task;
                    switch (action)
                    {
                        case 1:
                            taskPrinter.PrintTaskCollection(taskRepository.GetAll());
                            break;
                        case 2:
                            Console.WriteLine("We need you to enter the task id:");
                            id = int.Parse(Console.ReadLine()!);
                            taskPrinter.PrintTask(taskRepository.GetById(id));
                            break;
                        case 3:
                            Console.WriteLine("We need you to enter the task id:");
                            id = int.Parse(Console.ReadLine()!);

                            task = taskRepository.GetById(id);
                            Console.WriteLine("Now enter the task data:");
                            Console.WriteLine("Enter the title:");
                            task.Title = Console.ReadLine();
                            Console.WriteLine("Enter the content:");
                            task.Content = Console.ReadLine();

                            taskRepository.Update(task);
                            break;
                        case 4:
                            Console.WriteLine("We need you to enter the task id:");
                            id = int.Parse(Console.ReadLine()!);

                            taskRepository.DeleteById(id);
                            break;
                        case 5:
                            task = taskInitializer.InitializeTask(lifetime);

                            taskRepository.Add(task);
                            break;
                        default:
                            Console.WriteLine("You've choosen a wrong action. Let's try again!");
                            break;
                    }
                }
            }
        }
    }
}