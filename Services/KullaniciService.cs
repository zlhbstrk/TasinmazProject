using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tasinmaz.Services
{
    public class KullaniciService : IRepository<Kullanici>
    {
        public async Task<Kullanici> Add(Kullanici entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                using (SHA256 sha = SHA256.Create())
                {
                    byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(entity.Sifre));
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    entity.Sifre = builder.ToString();
                }
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

        public async Task<IList<Kullanici>> GetAll(int skipDeger, int takeDeger, int kullaniciId, int kullaniciYetki)
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
        public Task<Kullanici> Logout(string email, string sifre)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                throw new System.NotImplementedException();
            }
        }
    }
}