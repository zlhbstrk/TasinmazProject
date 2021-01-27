using System.Collections.Generic;
using System.Linq;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class IlService : IRepository<Il>
    {
        public Il Add(Il entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIl.Add(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenIl = GetById(id);
                _DefaultDbContext.tblIl.Remove(silinenIl);
                _DefaultDbContext.SaveChanges();
            }
        }

        public IList<Il> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblIl.ToList();
            }
        }

        public IList<Il> GetAllFilter(string filter) //Kullanmıyorum!
        {
            throw new System.NotImplementedException();
        }

        public Il GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblIl.Find(id);
            }
        }

        public Il Update(Il entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIl.Update(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }
    }
}