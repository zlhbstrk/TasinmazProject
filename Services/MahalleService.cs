using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class MahalleService : IRepository<Mahalle>
    {
        public async Task<Mahalle> Add(Mahalle entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblMahalle.Add(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenMahalle = await GetById(id);
                _DefaultDbContext.tblMahalle.Remove(silinenMahalle);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Mahalle>> GetAll(int skipDeger, int takeDeger, int kullaniciId)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                // return await _DefaultDbContext.tblMahalle.ToListAsync();

                IList<Mahalle> mahalleler = await _DefaultDbContext.tblMahalle.ToListAsync();
                IList<Ilce> ilceler = await _DefaultDbContext.tblIlce.ToListAsync();
                IList<Il> iller = await _DefaultDbContext.tblIl.ToListAsync();

                return (from il in iller
                        join ilce in ilceler on il.Id equals ilce.IlId
                        join mahalle in mahalleler on ilce.Id equals mahalle.IlceId
                        select new Mahalle()
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
                        }).Skip(skipDeger).Take<Mahalle>(takeDeger).ToList<Mahalle>();
                // return (await _DefaultDbContext.tblMahalle.ToListAsync<Mahalle>()).Skip(skipDeger).Take<Mahalle>(takeDeger).ToList<Mahalle>();
            }
        }
        public async Task<IList<Mahalle>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblMahalle.OrderBy(m => m.Ad).ToListAsync();
            }
        }
        public Task<IList<Mahalle>> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Mahalle> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                Mahalle mahalle = _DefaultDbContext.tblMahalle.Where<Mahalle>(m => m.Id == id).FirstOrDefault();
                Ilce ilce = _DefaultDbContext.tblIlce.Where<Ilce>(i => i.Id == mahalle.IlceId).FirstOrDefault();
                Il il = _DefaultDbContext.tblIl.Where<Il>(il => il.Id == ilce.IlId).FirstOrDefault();

                ilce.Il = il;
                mahalle.Ilce = ilce;

                return mahalle;
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (_DefaultDbContext.tblMahalle.CountAsync());
            }
        }

        public async Task<Mahalle> Update(Mahalle entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblMahalle.Update(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public Task<Mahalle> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}