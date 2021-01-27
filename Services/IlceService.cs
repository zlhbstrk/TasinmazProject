using System.Collections.Generic;
using System.Linq;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class IlceService : IRepository<Ilce>
    {
        public Ilce Add(Ilce entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIlce.Add(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenIlce = GetById(id);
                _DefaultDbContext.tblIlce.Remove(silinenIlce);
                _DefaultDbContext.SaveChanges();
            }
        }

        public IList<Ilce> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblIlce.ToList();
            }
        }

        public IList<Ilce> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public Ilce GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblIlce.Find(id);
            }
        }

        public Ilce Update(Ilce entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblIlce.Update(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }
    }
}