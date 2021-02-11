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
                _DefaultDbContext.tblTasinmaz.Remove(silinenTasinmaz);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<ETasinmaz>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<ETasinmaz> tasinmazlar = await _DefaultDbContext.tblTasinmaz.ToListAsync();
                IList<Mahalle> mahalleler = await _DefaultDbContext.tblMahalle.ToListAsync();
                IList<Ilce> ilceler = await _DefaultDbContext.tblIlce.ToListAsync();
                IList<Il> iller = await _DefaultDbContext.tblIl.ToListAsync();

                return (from il in iller
                        join ilce in ilceler on il.Id equals ilce.IlId
                        join mahalle in mahalleler on ilce.Id equals mahalle.IlceId
                        join tasinmaz in tasinmazlar on mahalle.Id equals tasinmaz.MahalleId
                        select new ETasinmaz()
                        {
                            Id = tasinmaz.Id,
                            Ada = tasinmaz.Ada,
                            Parsel = tasinmaz.Parsel,
                            Nitelik = tasinmaz.Nitelik,
                            Adres = tasinmaz.Adres,
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
                        }).ToList<ETasinmaz>();
                // return (await _DefaultDbContext.tblTasinmaz.ToListAsync<ETasinmaz>()).Skip(skipDeger).Take<ETasinmaz>(takeDeger).ToList<ETasinmaz>();
            }
        }
        public async Task<IList<ETasinmaz>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblTasinmaz.ToListAsync();
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
                return await (_DefaultDbContext.tblTasinmaz.CountAsync());
            }
        }

        public async Task<ETasinmaz> Update(ETasinmaz entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblTasinmaz.Update(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}