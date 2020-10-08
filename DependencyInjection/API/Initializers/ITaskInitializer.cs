using Autofac;
using DependencyInjection.Models;

namespace DependencyInjection.API.Initializers
{
    public interface ITaskInitializer
    {
        public UserTask InitializeTask(ILifetimeScope lifetimeScope);
    }
}