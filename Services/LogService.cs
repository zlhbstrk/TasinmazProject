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

        public async Task<IList<Log>> GetAllFilter(string filter)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (from l in _DefaultDbContext.tblLog
                              where
                                    l.KullaniciAdi.ToLower().Contains(filter.ToLower()) ||
                                    l.Durum.Ad.ToLower().Contains(filter.ToLower()) ||
                                    l.IslemTip.Ad.ToLower().Contains(filter.ToLower()) ||
                                    l.Aciklama.ToLower().Contains(filter.ToLower()) ||
                                    l.IP.Contains(filter)
                              select l).OrderByDescending(l => l.Tarih).ToListAsync();
            }
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