using System;
using ConsoleApp1.API.Attributes;
using ConsoleApp1.API.Enums;
using ConsoleApp1.Models;

namespace ConsoleApp1.API.DataSourceAccessers
{
    [DataSourceAccesser(AccesserType.Database)]
    public class DatabaseAccessser : IDataSourceAccesser
    {
        public User GetUser()
        {
            return new User(
                "DatabaseUserName",
                "DatabaseUserLocation",
                "DatabaseUserJob",
                "DatabaseUserProject");
        }

        public void AddUser(User user)
        {
            Console.WriteLine("A user has been added to memory");
        }
    }
}