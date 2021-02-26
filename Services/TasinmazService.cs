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

        public async Task<IList<ETasinmaz>> GetAllYetki(int skipDeger, int takeDeger, int kullaniciId, int kullaniciYetki)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                if (kullaniciYetki == 1)
                {
                    return await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                                            .Include(t => t.Kullanici).Where(t => t.AktifMi).OrderBy(t => t.Adres).Skip(skipDeger).Take(takeDeger).ToListAsync();
                }
                else
                {
                    return await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                                            .Include(t => t.Kullanici).OrderBy(t => t.Adres).Where(t => t.KullaniciId == kullaniciId && t.AktifMi).Skip(skipDeger).Take(takeDeger).ToListAsync();
                }
            }
        }
        public async Task<IList<ETasinmaz>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                            .Include(t => t.Kullanici).Where(t => t.AktifMi).OrderBy(t => t.Adres).ToListAsync();
            }
        }
        public async Task<IList<ETasinmaz>> GetAllFilter(string filter)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (from t in _DefaultDbContext.tblTasinmaz
                              where
                                    t.Mahalle.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Ilce.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Il.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Ada.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Parsel.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Nitelik.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Adres.ToLower().Contains(filter.Trim().ToLower())
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
                // entity.KullaniciId = 29;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public Task<ETasinmaz> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
        public Task<ETasinmaz> Logout()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<ETasinmaz>> GetAll(int skipDeger, int takeDeger)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<ETasinmaz>> GetSearchAndFilter(int skipDeger, int takeDeger, string filter)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<ETasinmaz> model;
                if (filter != "-1")
                {
                    model = await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).Include(t => t.Ilce).Include(t => t.Il)
                                .OrderBy(t => t.Adres)
                                .Where(t => t.Mahalle.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                            t.Ilce.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                            t.Il.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                            t.Ada.ToLower().Contains(filter.Trim().ToLower()) ||
                                            t.Parsel.ToLower().Contains(filter.Trim().ToLower()) ||
                                            t.Nitelik.ToLower().Contains(filter.Trim().ToLower()) ||
                                            t.Adres.ToLower().Contains(filter.Trim().ToLower()))
                                .Skip(skipDeger).Take(takeDeger).ToListAsync();
                }
                else
                {
                    model = await _DefaultDbContext.tblTasinmaz.Include(t => t.Mahalle).ThenInclude(t => t.Ilce).ThenInclude(t => t.Il)
                                 .OrderBy(t => t.Adres).Skip(skipDeger).Take(takeDeger).ToListAsync();
                }


                if (model == null)
                {
                    throw new System.NotImplementedException();
                }
                return model;
            }
        }

        public async Task<int> FilterGetCount(string filter)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.Where(t => t.Mahalle.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Ilce.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Il.Ad.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Ada.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Parsel.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Nitelik.ToLower().Contains(filter.Trim().ToLower()) ||
                                    t.Adres.ToLower().Contains(filter.Trim().ToLower())).CountAsync();
            }
        }

    }
}