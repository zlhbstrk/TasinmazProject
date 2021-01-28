using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class KullaniciService : IRepository<Kullanici>
    {
        public async Task<Kullanici> Add(Kullanici entity) //try - catch kullanmayı unutma // summray
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
                _DefaultDbContext.tblKullanici.Remove(silinenKullanici);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Kullanici>> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblKullanici.ToListAsync();
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

        public async Task<Kullanici> Update(Kullanici entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblKullanici.Update(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}