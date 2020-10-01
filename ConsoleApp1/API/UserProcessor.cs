using System;
using System.Diagnostics;
using ConsoleApp1.API.DataSourceAccessers;
using ConsoleApp1.API.Enums;
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

        public UserProcessor(AccesserType accesserType)
        {
            DataSourceAccesser = DataSourceAccesserFactory.Instance.GetAccesserForSource(accesserType);
        }

        public void SetDataAccesser(IDataSourceAccesser dataSourceAccesser)
        {
            DataSourceAccesser = dataSourceAccesser;
        }

        public void Process(OperationType operation)
        {
            if (operation == OperationType.Add)
            {
                var user = new User("Name", "Location", "Job", "Project");

                UserManager.AddUser(user);

                DataSourceAccesser.AddUser(user);
            }
            else if (operation == OperationType.Get)
            {
                UserManager.AddUser(DataSourceAccesser.GetUser());
                UserManager.PrintUsersToConsole();
            }
        }
    }
}