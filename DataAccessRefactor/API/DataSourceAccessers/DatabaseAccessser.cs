using System;
using DataAccessRefactor.API.Attributes;
using DataAccessRefactor.API.Enums;
using DataAccessRefactor.Models;

namespace DataAccessRefactor.API.DataSourceAccessers
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