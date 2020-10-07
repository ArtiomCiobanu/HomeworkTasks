using DataAccessRefactor.Models;

namespace DataAccessRefactor.API.DataSourceAccessers
{
    public interface IDataSourceAccesser
    {
        public User GetUser();
        public void AddUser(User user);
    }
}