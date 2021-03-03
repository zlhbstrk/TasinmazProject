using System.Collections.Generic;
using System.Threading.Tasks;
using Tasinmaz.Entities;

namespace Tasinmaz.Contracts
{
    public interface ILogRepository
    {
        Task<IList<Log>> FullGetAll(); 
        Task<IList<Log>> GetAll(int skipDeger, int takeDeger);
        Task<int> GetCount(); 
        Task<int> FilterGetCount(string filter); 
        Task<Log> Add(Log entity); 
        Task<IList<Log>> GetAllFilter(string filter); 
        Task<IList<Log>> GetSearchAndFilter(int skipDeger, int takeDeger, string filter);
    }
}