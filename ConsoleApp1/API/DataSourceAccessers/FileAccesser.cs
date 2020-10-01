using System;
using System.IO;
using ConsoleApp1.API.Attributes;
using ConsoleApp1.API.Enums;
using ConsoleApp1.Models;

namespace ConsoleApp1.API.DataSourceAccessers
{
    [DataSourceAccesser((AccesserType.File))]
    public class FileAccesser : IDataSourceAccesser
    {
        public User GetUser()
        {
            return new User(
                "FileUserName",
                "FileLocation",
                "FileJob",
                "FileProject");
        }

        public void AddUser(User user)
        {
            Console.WriteLine("A user has been added to the json file");
        }
    }
}