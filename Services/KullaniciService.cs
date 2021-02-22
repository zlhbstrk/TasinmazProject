using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using System.Linq;

namespace Tasinmaz.Services
{
    public class KullaniciService : IRepository<Kullanici>
    {
        public async Task<Kullanici> Add(Kullanici entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblKullanici.Add(entity);
                //entity.Sifre = SHA256()
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenKullanici = await GetById(id);
                silinenKullanici.AktifMi = false;
                _DefaultDbContext.tblKullanici.Update(silinenKullanici);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Kullanici>> GetAll(int skipDeger, int takeDeger, int kullaniciId)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblKullanici.Where(k => k.AktifMi).OrderBy(k => k.Ad).Skip(skipDeger).Take(takeDeger).ToListAsync();
            }
        }

        public async Task<IList<Kullanici>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblKullanici.Where(k => k.AktifMi).OrderBy(k => k.Ad).ToListAsync();
            }
        }

        public Task<IList<Kullanici>> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Kullanici> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblKullanici.FirstOrDefaultAsync(k => k.Id == id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblKullanici.Where(k => k.AktifMi).CountAsync();
            }
        }

        public async Task<Kullanici> Update(Kullanici entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblKullanici.Update(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<Kullanici> Login(string email, string sifre)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var liste = await _DefaultDbContext.tblKullanici.Where(k => k.Email == email && k.Sifre == sifre && k.AktifMi).ToListAsync();

                if (liste.Count > 0)
                {
                    liste[0].Sifre = null;
                    return liste[0];
                }
                else
                {
                    return null;
                }
            }
        }
    }
}