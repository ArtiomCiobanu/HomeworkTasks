using System;
using System.Diagnostics;
using ConsoleApp1.API.DataSourceAccessers;
using ConsoleApp1.API.Static_classes;
using ConsoleApp1.Models;

namespace ConsoleApp1.API
{
    public class UserProcessor
    {
        private IDataSourceAccesser DataSourceAccesser { get; set; }

        public UserProcessor()
        {
        }

        public UserProcessor(IDataSourceAccesser dataSourceAccesser)
        {
            DataSourceAccesser = dataSourceAccesser;
        }

        public void SetSaver(IDataSourceAccesser dataSourceAccesser)
        {
            DataSourceAccesser = dataSourceAccesser;
        }

        public void Process(string operation)
        {
            if (operation == "Add")
            {
                var user = new User()
                {
                    Name = "Name",
                    Location = "Location",
                    Job = "Job",
                    Project = "Project"
                };

                UserManager.AddUser(user);

                DataSourceAccesser.AddUser(user);
            }
            else if (operation == "Get")
            {
                UserManager.AddUser(DataSourceAccesser.GetUser());
                UserManager.PrintUsersToConsole();
            }
            else
            {
                throw new ArgumentException("source should be either Add or Get");
            }
        }
    }
}