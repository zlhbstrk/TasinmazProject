using System.Collections.Generic;

namespace Tasinmaz.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);
        IList<T> GetAll();
        T Add(T entity);
        void Delete(int id);
        T Update(T entity);
        IList<T> GetAllFilter(string filter);
    }
}