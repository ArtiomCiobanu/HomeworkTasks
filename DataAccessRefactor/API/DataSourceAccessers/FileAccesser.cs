using System;
using System.IO;
using DataAccessRefactor.API.Attributes;
using DataAccessRefactor.API.Enums;
using DataAccessRefactor.Models;

namespace DataAccessRefactor.API.DataSourceAccessers
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