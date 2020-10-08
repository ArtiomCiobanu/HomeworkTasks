using System;
using System.Linq;
using Autofac;
using DependencyInjection.API.DataSourceAccessers;
using DependencyInjection.API.Repositories;
using DependencyInjection.Models;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"UserTasks.json";

            var builder = new ContainerBuilder();

            builder.Register(ja => new JsonTaskAccesser(path))
                .As<IDataSourceAccesser>();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>().SingleInstance();
            builder.RegisterType<UserTask>().As<IUserTask>();

            var container = builder.Build();

            using (var lifetime = container.BeginLifetimeScope())
            {
                var taskRepository = container.Resolve<ITaskRepository>();

                var result = taskRepository.GetAllTasks().ToList();

                Console.WriteLine($"Total amount of tasks: {result.Count}");
                foreach (var userTask in result)
                {
                    var task = (UserTask) userTask;

                    Console.WriteLine();
                    Console.WriteLine($"{task.Title}:");
                    Console.WriteLine(task.Content);
                }

                Console.WriteLine();
                Console.WriteLine("Getting a task with id = 2: ");
                var foundTask = (UserTask) taskRepository.GetTaskById(2);
                Console.WriteLine($"{foundTask.Title}:");
                Console.WriteLine(foundTask.Content);

                foundTask.Title = "Updated Task2 Title!";
                taskRepository.UpdateTask(foundTask);
            }
        }
    }
}