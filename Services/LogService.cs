using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class LogService : IRepository<Log>
    {
        public async Task<Log> Add(Log entity)
        {
            //KullaniciID = token'dan çekilecek,
            //KullaniciAdi = token'dan çekilecek,
            //Tarih = DateTime.Now kullanılacak,
            //IP = "js ile çekilmeye çalışılacak" 
            // throw new System.NotImplementedException();
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblLog.Add(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Log>> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblLog.ToListAsync();
            }
        }

        public Task<IList<Log>> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<Log> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Log> Update(Log entity)
        {
            throw new System.NotImplementedException();
        }
    }
}