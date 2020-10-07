using System;
using System.Diagnostics;
using DataAccessRefactor.API.DataSourceAccessers;
using DataAccessRefactor.API.Enums;
using DataAccessRefactor.API.Static_classes;
using DataAccessRefactor.Models;

namespace DataAccessRefactor.API
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
            switch (operation)
            {
                case OperationType.Add:
                    var user = new User("Name", "Location", "Job", "Project");

                    UserManager.AddUser(user);

                    DataSourceAccesser.AddUser(user);
                    break;
                case OperationType.Get:
                    UserManager.AddUser(DataSourceAccesser.GetUser());
                    UserManager.PrintUsersToConsole();
                    break;
                default:
                    break;
            }
        }
    }
}