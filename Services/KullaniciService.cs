using System.Collections.Generic;
using System.Linq;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class KullaniciService : IRepository<Kullanici>
    {
        public Kullanici Add(Kullanici entity) //try - catch kullanmayı unutma // summray
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblKullanici.Add(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenKullanici = GetById(id);
                _DefaultDbContext.tblKullanici.Remove(silinenKullanici);
                _DefaultDbContext.SaveChanges();
            }
        }

        public IList<Kullanici> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblKullanici.ToList();
            }
        }

        public Kullanici GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblKullanici.Find(id);
            }
        }

        public Kullanici Update(Kullanici entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblKullanici.Update(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }

        public IList<Kullanici> GetAllFilter(string filter)
        {
            throw new System.NotImplementedException();
        }
    }
}