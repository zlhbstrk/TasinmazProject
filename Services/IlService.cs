using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class IlService : IRepository<Il>
    {
        public async Task<Il> Add(Il entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIl.Add(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }

        public async Task Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenIl = await GetById(id);
                _DefaultDbContext.tblIl.Remove(silinenIl);
                await _DefaultDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<Il>> GetAll(int skipDeger, int takeDeger)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return (await _DefaultDbContext.tblIl.ToListAsync<Il>()).Skip(skipDeger).Take<Il>(takeDeger).ToList<Il>();
            }
        }
        public async Task<IList<Il>> FullGetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIl.ToListAsync();
            }
        }

        public Task<IList<Il>> GetAllFilter(string filter) //Kullanmıyorum!
        {
            throw new System.NotImplementedException();
        }

        public async Task<Il> GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblIl.FindAsync(id);
            }
        }

        public async Task<int> GetCount()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await (_DefaultDbContext.tblIl.CountAsync());
            }
        }

        public async Task<Il> Update(Il entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIl.Update(entity);
                await _DefaultDbContext.SaveChangesAsync();
                return entity;
            }
        }
    }
}