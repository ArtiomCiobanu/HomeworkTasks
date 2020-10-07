using ConsoleApp1.Models;

namespace ConsoleApp1.API.DataSourceAccessers
{
    public interface IDataSourceAccesser
    {
        public User GetUser();
        public void AddUser(User user);
    }
}