using System.Collections.Generic;
using System.Linq;
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
            // KullaniciID = Local Storage 'den alınan veri ile dolacak!
            // KullaniciAdi = Local Storage 'den alınan veri ile dolacak!
            // IP = "js ile çekilmeye çalışılacak" 
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

        public async Task<IList<Log>> GetAll(int skipDeger, int takeDeger, int kullaniciId)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Log> model = await _DefaultDbContext.tblLog.Include(l => l.Kullanici).Include(l => l.Durum).Include(l => l.IslemTip)
                                    .OrderByDescending(l => l.Tarih).Skip(skipDeger).Take(takeDeger).ToListAsync();

                if (model == null)
                {
                    throw new System.NotImplementedException();
                }
                return model;
            }
        }
        public async Task<IList<Log>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblLog.Include(l => l.Kullanici).Include(l => l.Durum).Include(l => l.IslemTip)
                        .OrderBy(l => l.Tarih).ToListAsync();
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

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblLog.CountAsync();
            }
        }

        public Task<Log> Update(Log entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<Log> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}