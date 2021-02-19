using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using System.Linq;

namespace Tasinmaz.Services
{
    public class IlceService : IRepository<Ilce>
    {
        public async Task<Ilce> Add(Ilce entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIlce.Add(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenIlce = await GetById(id);
                _DefaultDbContext.tblIlce.Remove(silinenIlce);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Ilce>> GetAll(int skipDeger, int takeDeger, int kullaniciId)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Ilce> ilceler = await _DefaultDbContext.tblIlce.ToListAsync();
                IList<Il> iller = await _DefaultDbContext.tblIl.ToListAsync();

                // var model = _DefaultDbContext.tblIlce.Include(m => m.Il).ToListAsync();
                

                return (from ilce in ilceler
                        join il in iller on ilce.IlId equals il.Id
                        select new Ilce()
                        {
                            Id = ilce.Id,
                            Ad = ilce.Ad,
                            IlId = ilce.IlId,
                            Il = new Il()
                            {
                                Ad = il.Ad,
                                Id = il.Id,
                                Plaka = il.Plaka
                            }
                        }).OrderBy(i => i.Ad).Skip(skipDeger).Take<Ilce>(takeDeger).ToList<Ilce>();
                
                // return (await _DefaultDbContext.tblIlce.ToListAsync<Ilce>()).Skip(skipDeger).Take<Ilce>(takeDeger).ToList<Ilce>();

                // var model = (await _DefaultDbContext.tblIlce.ToListAsync<Ilce>()).Include(x => x.Il.Where(k => IlId == k.Id)).ToList<Ilce>();
                // if (model != null)
                // {
                //     Ilce Ilce = new Ilce();
                //     Il Il = new Il();
                // }

                
            }
        }

        public async Task<IList<Ilce>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIlce.OrderBy(i => i.Ad).ToListAsync();
            }
        }

        public Task<IList<Ilce>> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Ilce> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIlce.FindAsync(id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (_DefaultDbContext.tblIlce.CountAsync());
            }
        }

        public async Task<Ilce> Update(Ilce entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIlce.Update(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public Task<Ilce> Login(string email, string sifre)
        {
            throw new System.NotImplementedException();
        }
    }
}