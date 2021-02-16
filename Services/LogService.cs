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
            //KullaniciID = token'dan çekilecek,
            //KullaniciAdi = token'dan çekilecek,
            //Tarih = DateTime.Now kullanılacak,
            //IP = "js ile çekilmeye çalışılacak" 
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

        public async Task<IList<Log>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Durum> durumlar = await _DefaultDbContext.tblDurum.ToListAsync();
                IList<IslemTip> islemTipleri = await _DefaultDbContext.tblIslemTip.ToListAsync();
                IList<Kullanici> kullanicilar = await _DefaultDbContext.tblKullanici.ToListAsync();
                IList<Log> loglar = await _DefaultDbContext.tblLog.ToListAsync();

                return (from log in loglar 
                        join kullanici in kullanicilar on log.KullaniciId equals kullanici.Id
                        join durum in durumlar on log.DurumId equals durum.Id
                        join islemTip in islemTipleri on log.IslemTipId equals islemTip.Id
                        select new Log()
                        {
                            Id = log.Id,
                            KullaniciAdi = log.KullaniciAdi,
                            KullaniciId = log.KullaniciId,
                            Kullanici = new Kullanici()
                            {
                                Email = kullanici.Email,
                                Yetki = kullanici.Yetki,
                                Sifre = kullanici.Sifre,
                                Ad = kullanici.Ad,
                                Soyad = kullanici.Soyad,
                                AktifMi = true
                            },
                            DurumId = log.DurumId,
                            Durum = new Durum()
                            {
                                Ad = durum.Ad
                            },
                            IslemTipId = log.IslemTipId,
                            IslemTip = new IslemTip()
                            {
                                Ad = islemTip.Ad
                            },
                            Aciklama = log.Aciklama,
                            Tarih = log.Tarih,
                            IP = log.IP                            
                        }).OrderByDescending(l => l.Tarih).Skip(skipDeger).Take<Log>(takeDeger).ToList<Log>();
                //return (await _DefaultDbContext.tblLog.ToListAsync<Log>()).Skip(skipDeger).Take<Log>(takeDeger).ToList<Log>();
            }
        }
        public async Task<IList<Log>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblLog.OrderBy(l => l.Tarih).ToListAsync();
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
                return await (_DefaultDbContext.tblLog.CountAsync());
            }
        }

        public Task<Log> Update(Log entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}