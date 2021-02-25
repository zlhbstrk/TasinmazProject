using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class IlService : IRepository<Il>
    {
        public async Task<Il> Add(Il entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIl.Add(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenIl = await GetById(id);
                silinenIl.AktifMi = false;
                _DefaultDbContext.tblIl.Update(silinenIl);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Il>> GetAll(int skipDeger, int takeDeger, int kullaniciId, int kullaniciYetki)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIl.Where(i => i.AktifMi).OrderBy(i => i.Plaka).Skip(skipDeger).Take(takeDeger).ToListAsync();
            }
        }
        public async Task<IList<Il>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIl.Where(i => i.AktifMi).OrderBy(i => i.Ad).ToListAsync();
            }
        }

        public Task<IList<Il>> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Il> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIl.FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIl.Where(i => i.AktifMi).CountAsync();
            }
        }

        public async Task<Il> Update(Il entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIl.Update(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public Task<Il> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
        public Task<Il> Logout(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}