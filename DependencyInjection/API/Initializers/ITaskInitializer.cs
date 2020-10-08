using Autofac;
using DependencyInjection.Models;

namespace DependencyInjection.API.Initializers
{
    public interface ITaskInitializer
    {
        public IUserTask InitializeTask(ILifetimeScope lifetimeScope);
    }
}