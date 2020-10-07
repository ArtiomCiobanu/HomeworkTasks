using System;
using DataAccessRefactor.API.Attributes;
using DataAccessRefactor.API.Enums;
using DataAccessRefactor.Models;

namespace DataAccessRefactor.API.DataSourceAccessers
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