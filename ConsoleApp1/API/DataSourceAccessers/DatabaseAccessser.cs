using System;
using ConsoleApp1.API.Attributes;
using ConsoleApp1.Models;

namespace ConsoleApp1.API.DataSourceAccessers
{
    [DataSourceAccesser(AccesserType.Database)]
    public class DatabaseAccessser : IDataSourceAccesser
    {
        public User GetUser()
        {
            return new User()
            {
                Name = "DatabaseUserName",
                Location = "DatabaseUserLocation",
                Job = "DatabaseUserJob",
                Project = "DatabaseUserProject"
            };
        }

        public void AddUser(User user)
        {
            Console.WriteLine("A user has been added to memory");
        }
    }
}