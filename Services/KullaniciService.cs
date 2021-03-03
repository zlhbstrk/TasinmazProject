using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using Tasinmaz.Helpers;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Tasinmaz.Models;

namespace Tasinmaz.Services
{
    public class KullaniciService : IKullaniciRepository
    {
        public async Task<Kullanici> Add(Kullanici entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                entity.Sifre = Helper.Sifreleme(entity.Sifre);
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
                sifre = Helper.Sifreleme(sifre);
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
        public Task<Kullanici> Logout()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                throw new System.NotImplementedException();
            }
        }

        public async Task<bool> PasswordChange(PasswordChangeDto entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var kullanici = _DefaultDbContext.tblKullanici.Find(entity.Id);
                kullanici.Sifre = Helper.Sifreleme(entity.YeniSifre);
                _DefaultDbContext.tblKullanici.Update(kullanici);
                await _DefaultDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> PasswordControl(int id, string password)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                password = Helper.Sifreleme(password);
                var liste = await _DefaultDbContext.tblKullanici.Where(k => k.Id == id && k.Sifre == password).ToListAsync();
                if (liste.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}