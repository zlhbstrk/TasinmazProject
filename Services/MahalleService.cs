using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class MahalleService : IMahalleRepositoryy
    {
        public async Task<Mahalle> Add(Mahalle entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblMahalle.Add(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenMahalle = await GetById(id);
                silinenMahalle.AktifMi = false;
                _DefaultDbContext.tblMahalle.Update(silinenMahalle);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Mahalle>> GetAll(int skipDeger, int takeDeger )
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                IList<Mahalle> model = await _DefaultDbContext.tblMahalle.Include(m => m.Ilce).ThenInclude(m => m.Il)
                                        .Where(m => m.AktifMi).OrderBy(m => m.Ad).Skip(skipDeger).Take(takeDeger).ToListAsync();

                if (model == null)
                {
                    throw new System.NotImplementedException();
                }
                return model;
            }
        }
        public async Task<IList<Mahalle>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblMahalle.Include(m => m.Ilce).ThenInclude(m => m.Il).Where(m => m.AktifMi).OrderBy(m => m.Ad).ToListAsync();
            }
        }

        public async Task<Mahalle> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                Mahalle model = await _DefaultDbContext.tblMahalle.Include(m => m.Ilce).ThenInclude(m => m.Il).FirstOrDefaultAsync(m => m.Id == id);

                if (model == null)
                {
                    throw new System.NotImplementedException();
                }
                return model;
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblMahalle.Where(m => m.AktifMi).CountAsync();
            }
        }

        public async Task<Mahalle> Update(Mahalle entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblMahalle.Update(entity);
                entity.AktifMi = true;
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}