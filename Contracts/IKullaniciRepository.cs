using System.Threading.Tasks;
using Tasinmaz.Entities;
using Tasinmaz.Models;

namespace Tasinmaz.Contracts
{
    public interface IKullaniciRepository : IRepository<Kullanici>
    {
        Task<Kullanici> Login(string email, string sifre);
        Task<Kullanici> Logout();
        Task<bool> PasswordChange(PasswordChangeDto entity);
        Task<bool> PasswordControl(int id, string password);
    }
}