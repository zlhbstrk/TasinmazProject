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

        public async Task<IList<Ilce>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Ilce> ilceler = await _DefaultDbContext.tblIlce.ToListAsync();
                IList<Il> iller = await _DefaultDbContext.tblIl.ToListAsync();

                return (from il in iller
                        join ilce in ilceler on il.Id equals ilce.IlId
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
                        }).ToList<Ilce>();
                
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
                return await _DefaultDbContext.tblIlce.ToListAsync();
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
    }
}