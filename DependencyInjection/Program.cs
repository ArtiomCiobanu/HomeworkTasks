using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using DIHomeworkCiobanuArtiom.API.DataSourceAccessers;
using DIHomeworkCiobanuArtiom.API.Repositories;
using DIHomeworkCiobanuArtiom.Models;

namespace DIHomeworkCiobanuArtiom
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