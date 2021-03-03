using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;
using System.Linq;

namespace Tasinmaz.Services
{
    public class IlceService : IIlceRepository
    {
        public async Task<Ilce> Add(Ilce entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIlce.Add(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenIlce = await GetById(id);
                silinenIlce.AktifMi = false;
                _DefaultDbContext.tblIlce.Update(silinenIlce);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Ilce>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Ilce> model = await _DefaultDbContext.tblIlce.Include(i => i.Il).Where(i => i.AktifMi).OrderBy(i => i.Ad).Skip(skipDeger).Take(takeDeger).ToListAsync();

                if (model == null)
                {
                    throw new System.NotImplementedException();
                }
                return model;
            }
        }

        public async Task<IList<Ilce>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIlce.Include(i => i.Il).Where(i => i.AktifMi).OrderBy(i => i.Ad).ToListAsync();
            }
        }

        public async Task<Ilce> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIlce.Include(i => i.Il).FirstOrDefaultAsync(i => i.Id == id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIlce.Where(i => i.AktifMi).CountAsync();
            }
        }

        public async Task<Ilce> Update(Ilce entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIlce.Update(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}