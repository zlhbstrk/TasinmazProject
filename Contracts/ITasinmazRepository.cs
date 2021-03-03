using System.Collections.Generic;
using System.Threading.Tasks;
using Tasinmaz.Entities;

namespace Tasinmaz.Contracts
{
    public interface ITasinmazRepository : IRepository<ETasinmaz>
    {
        Task<int> FilterGetCount(string filter);
        Task<IList<ETasinmaz>> GetAllFilter(string filter);
        Task<IList<ETasinmaz>> GetAllYetki(int skipDeger, int takeDeger, int kullaniciId, int kullaniciYetki);
        Task<IList<ETasinmaz>> GetSearchAndFilter(int skipDeger, int takeDeger, string filter);
    }
}