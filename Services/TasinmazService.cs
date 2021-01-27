using System.Collections.Generic;
using System.Linq;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class TasinmazService : IRepository<ETasinmaz>
    {
        public ETasinmaz Add(ETasinmaz entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblTasinmaz.Add(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }

        public void Delete(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                var silinenTasinmaz = GetById(id);
                _DefaultDbContext.tblTasinmaz.Remove(silinenTasinmaz);
                _DefaultDbContext.SaveChanges();
            }
        }

        public IList<ETasinmaz> GetAll()
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblTasinmaz.ToList();
            }
        }

        public IList<ETasinmaz> GetAllFilter(string filter)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return (from t in _DefaultDbContext.tblTasinmaz
                        where t.Nitelik.ToUpper().Contains(filter.ToUpper()) || t.Adres.ToUpper().Contains(filter.ToUpper())
                        select t).ToList();
            }
        }

        public ETasinmaz GetById(int id)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                return _DefaultDbContext.tblTasinmaz.Find(id);
            }
        }

        public ETasinmaz Update(ETasinmaz entity)
        {
            using (var _DefaultDbContext = new DefaultDbContext())
            {
                _DefaultDbContext.tblTasinmaz.Update(entity);
                _DefaultDbContext.SaveChanges();
                return entity;
            }
        }
    }
}