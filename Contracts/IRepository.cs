using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tasinmaz.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
        Task<T> Add(T entity);
        Task Delete(int id);
        Task<T> Update(T entity);
        Task<IList<T>> GetAllFilter(string filter);
    }
}