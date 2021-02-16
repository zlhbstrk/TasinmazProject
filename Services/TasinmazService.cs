using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using Tasinmaz.Models;

namespace Tasinmaz.Services
{
    public class TasinmazService : IRepository<ETasinmaz>
    {
        public async Task<ETasinmaz> Add(ETasinmaz entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblTasinmaz.Add(entity);
                entity.KullaniciId = 29;
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

        public async Task<IList<ETasinmaz>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Kullanici> kullanicilar = await _DefaultDbContext.tblKullanici.ToListAsync();
                IList<ETasinmaz> tasinmazlar = await _DefaultDbContext.tblTasinmaz.ToListAsync();
                IList<Mahalle> mahalleler = await _DefaultDbContext.tblMahalle.ToListAsync();
                IList<Ilce> ilceler = await _DefaultDbContext.tblIlce.ToListAsync();
                IList<Il> iller = await _DefaultDbContext.tblIl.ToListAsync();

                return (from tasinmaz in tasinmazlar
                        join kullanici in kullanicilar on tasinmaz.KullaniciId equals kullanici.Id
                        join il in iller on tasinmaz.IlId equals il.Id
                        join ilce in ilceler on il.Id equals ilce.IlId
                        join mahalle in mahalleler on ilce.Id equals mahalle.IlceId
                        select new ETasinmaz()
                        {
                            Id = tasinmaz.Id,
                            Ada = tasinmaz.Ada,
                            Parsel = tasinmaz.Parsel,
                            Nitelik = tasinmaz.Nitelik,
                            Adres = tasinmaz.Adres,
                            AktifMi = tasinmaz.AktifMi,
                            KullaniciId = tasinmaz.KullaniciId,
                            Kullanici = new Kullanici()
                            {
                                Id = kullanici.Id,
                                Email = kullanici.Email,
                                Yetki = kullanici.Yetki,
                                Sifre = kullanici.Sifre,
                                Ad = kullanici.Ad,
                                Soyad = kullanici.Soyad,
                                AktifMi = kullanici.AktifMi
                            },
                            MahalleId = tasinmaz.MahalleId,
                            Mahalle = new Mahalle()
                            {
                                Id = mahalle.Id,
                                Ad = mahalle.Ad,
                                IlceId = mahalle.IlceId,
                                Ilce = new Ilce()
                                {
                                    Ad = ilce.Ad,
                                    Id = ilce.Id,
                                    IlId = ilce.IlId,
                                    Il = new Il()
                                    {
                                        Id = il.Id,
                                        Ad = il.Ad,
                                        Plaka = il.Plaka
                                    }
                                }
                            }
                        }).OrderBy(t => t.Adres).Where(t => t.AktifMi).Skip(skipDeger).Take<ETasinmaz>(takeDeger).ToList<ETasinmaz>();
                // return (await _DefaultDbContext.tblTasinmaz.ToListAsync<ETasinmaz>()).Skip(skipDeger).Take<ETasinmaz>(takeDeger).ToList<ETasinmaz>();
            }
        }
        public async Task<IList<ETasinmaz>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return (await _DefaultDbContext.tblTasinmaz.OrderBy(t => t.Adres).ToListAsync<ETasinmaz>()).Where(t => t.AktifMi).ToList<ETasinmaz>();
            }
        }
        public async Task<IList<ETasinmaz>> GetAllFilter(string filter) //ToUpper()-büyük/küçük harf duyarlılığı için
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (from t in _DefaultDbContext.tblTasinmaz
                              where t.Nitelik.ToUpper().Contains(filter.ToUpper()) || t.Adres.ToUpper().Contains(filter.ToUpper())
                              select t).ToListAsync();
            }
        }

        public async Task<ETasinmaz> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.FindAsync(id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (_DefaultDbContext.tblTasinmaz.Where(t => t.AktifMi)).CountAsync();
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

        public Task<bool> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}