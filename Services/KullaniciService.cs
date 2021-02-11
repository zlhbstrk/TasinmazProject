using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using System.Linq;
using System.Configuration;

namespace Tasinmaz.Services
{
    public class KullaniciService : IRepository<Kullanici>
    {
        public async Task<Kullanici> Add(Kullanici entity) // summray
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblKullanici.Add(entity);
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

        public async Task<IList<Kullanici>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return (await _DefaultDbContext.tblKullanici.ToListAsync<Kullanici>()).Where(k => k.AktifMi == true).Skip(skipDeger).Take<Kullanici>(takeDeger).ToList<Kullanici>();
            }
        }

        public async Task<IList<Kullanici>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return (await _DefaultDbContext.tblKullanici.ToListAsync<Kullanici>()).Where(k => k.AktifMi == true).ToList<Kullanici>();
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
                return await _DefaultDbContext.tblKullanici.FindAsync(id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (_DefaultDbContext.tblKullanici.CountAsync());
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
    }
}