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

            ContainerBuilder builder = new ContainerBuilder();

            builder.Register<JsonAccesser>(ja => new JsonAccesser(path))
                .As<IDataSourceAccesser<UserTask>>();
            builder.RegisterType<TaskRepository>().As<ITaskRepository>();

            var container = builder.Build();

            using (var lifetime = container.BeginLifetimeScope())
            {
                var taskRepository = container.Resolve<ITaskRepository>();

                var result = taskRepository.GetAllTasks().ToList();
                Console.WriteLine(result.Count);
            }
        }
    }
}