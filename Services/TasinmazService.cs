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

        public async Task<IList<ETasinmaz>> GetAll()
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
                return  await (from t in _DefaultDbContext.tblTasinmaz
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