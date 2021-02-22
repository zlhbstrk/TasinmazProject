using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class TasinmazService : IRepository<ETasinmaz>
    {
        public async Task<ETasinmaz> Add(ETasinmaz entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblTasinmaz.Add(entity);
                entity.KullaniciId = 29; //Log Add() -> Local Storage 'den alınan veri ile dolacak!
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenTasinmaz = await GetById(id);
                silinenTasinmaz.AktifMi = false;
                _DefaultDbContext.tblTasinmaz.Update(silinenTasinmaz);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<ETasinmaz>> GetAll(int skipDeger, int takeDeger, int kullaniciId)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<ETasinmaz> model = await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                                            .Include(t => t.Kullanici).OrderBy(t => t.Adres).Where(t => t.AktifMi).Skip(skipDeger).Take(takeDeger).ToListAsync();

                if (model == null)
                {
                    throw new System.NotImplementedException(); //*
                }
                return model;
            }
        }
        public async Task<IList<ETasinmaz>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                            .Include(t => t.Kullanici).OrderBy(t => t.Adres).Where(t => t.AktifMi).ToListAsync();
            }
        }
        public async Task<IList<ETasinmaz>> GetAllFilter(string filter)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (from t in _DefaultDbContext.tblTasinmaz
                              where
                                    t.Mahalle.Ad.ToLower().Contains(filter.ToLower()) ||
                                    t.Ilce.Ad.ToLower().Contains(filter.ToLower()) ||
                                    t.Il.Ad.ToLower().Contains(filter.ToLower()) ||
                                    t.Ada.ToLower().Contains(filter.ToLower()) ||
                                    t.Parsel.ToLower().Contains(filter.ToLower()) ||
                                    t.Nitelik.ToLower().Contains(filter.ToLower()) ||
                                    t.Adres.ToLower().Contains(filter.ToLower())
                              select t).Where(t => t.AktifMi).OrderBy(t => t.Adres).ToListAsync();
            }
        }

        public async Task<ETasinmaz> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                            .Include(t => t.Kullanici).OrderBy(t => t.Adres).FirstOrDefaultAsync(t => t.Id == id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.Where(t => t.AktifMi).CountAsync();
            }
        }

        public async Task<ETasinmaz> Update(ETasinmaz entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblTasinmaz.Update(entity);
                entity.AktifMi = true;
                entity.KullaniciId = 29;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public Task<ETasinmaz> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}