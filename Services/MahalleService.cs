using System.Collections.Generic;
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

        public async Task<IList<Mahalle>> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblMahalle.ToListAsync();
            }
        }

        public async Task<IList<Mahalle>> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Mahalle> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblMahalle.FindAsync(id);
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
    }
}