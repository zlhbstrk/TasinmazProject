using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tasinmaz.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<T> Login(string email, string sifre);
        Task<T> Logout(string email, string sifre);
        Task<IList<T>> FullGetAll();
        Task<IList<T>> GetAll(int skipDeger, int takeDeger, int kullaniciId, int kullaniciYetki);
        Task<int> GetCount();
        Task<T> Add(T entity);
        Task Delete(int id);
        Task<T> Update(T entity);
        Task<IList<T>> GetAllFilter(string filter);
    }
}