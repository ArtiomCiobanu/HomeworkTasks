using System;
using ConsoleApp1.Models;

namespace ConsoleApp1.API.DataSourceAccessers
{
    public class MemoryAccesser : IDataSourceAccesser
    {
        public User GetUser()
        {
            return new User()
            {
                Name = "MemoryUserName",
                Location = "MemoryUserLocation",
                Job = "MemoryUserJob",
                Project = "MemoryUserProject"
            };
        }

        public void AddUser(User user)
        {
            Console.WriteLine("A user has been added to memory");
        }
    }
}