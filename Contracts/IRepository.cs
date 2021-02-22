using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tasinmaz.Contracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id); //log kulanmıyor
        Task<T> Login(string email, string sifre); //sadece kullanıcı kullanıyor
        Task<IList<T>> FullGetAll(); //log kullanmıyor
        Task<IList<T>> GetAll(int skipDeger, int takeDeger, int kullaniciId);
        Task<int> GetCount();
        Task<T> Add(T entity);
        Task Delete(int id); //log kullanmıyor
        Task<T> Update(T entity); //log kullanmıyor
        Task<IList<T>> GetAllFilter(string filter); //sadece tasınmaz ve log kullanıyor
    }
}