using System.Collections.Generic;
using System.Linq;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class MahalleService : IRepository<Mahalle>
    {
        public Mahalle Add(Mahalle entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblMahalle.Add(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenMahalle = GetById(id);
                _DefaultDbContext.tblMahalle.Remove(silinenMahalle);
                _DefaultDbContext.SaveChanges();
            }
        }

        public IList<Mahalle> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblMahalle.ToList();
            }
        }

        public IList<Mahalle> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }

        public Mahalle GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblMahalle.Find(id);
            }
        }

        public Mahalle Update(Mahalle entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblMahalle.Update(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }
    }
}