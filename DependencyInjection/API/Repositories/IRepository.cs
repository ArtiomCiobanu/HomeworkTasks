using System.Collections.Generic;

namespace DependencyInjection.API.Repositories
{
    public interface IRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
        void Update(TModel dataModel);
        void Add(TModel dataModel);
        void Delete(TModel dataModel);
        void DeleteById(int id);
    }
}