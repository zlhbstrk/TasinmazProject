using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class LogService : IRepository<Log>
    {
        public Task<Log> Add(Log entity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IList<Log>> GetAll()
        {
             using (var _DefaultDbContext = new DefaultDbContext())
            {
                return await _DefaultDbContext.tblLog.ToListAsync();
            }
        }

        public Task<IList<Log>> GetAllFilter(string filter)
        {
            // using (var _DefaultDbContext = new DefaultDbContext())
            // {
            //     return  await (from l in _DefaultDbContext.tblLog 
            //             where l.Aciklama.ToUpper().Contains(filter.ToUpper())
            //             select l).ToListAsync();
            // }
            throw new System.NotImplementedException();
        }

        public Task<Log> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Log> Update(Log entity)
        {
            throw new System.NotImplementedException();
        }
    }
}