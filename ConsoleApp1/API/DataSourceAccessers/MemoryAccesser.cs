using System;
using ConsoleApp1.API.Attributes;
using ConsoleApp1.API.Enums;
using ConsoleApp1.Models;

namespace ConsoleApp1.API.DataSourceAccessers
{
    [DataSourceAccesser(AccesserType.Memory)]
    public class MemoryAccesser : IDataSourceAccesser
    {
        public User GetUser()
        {
            return new User(
                "MemoryName",
                "MemoryLocation",
                "MemoryJob",
                "MemoryProject");
        }

        public void AddUser(User user)
        {
            Console.WriteLine("A user has been added to memory");
        }
    }
}