using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Tasinmaz.Contracts;
using Tasinmaz.Entities;

namespace Tasinmaz.Services
{
    public class KullaniciService : IRepository<Kullanici>
    {
        public void Add(Kullanici entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Kullanici> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kullanici> Find(Expression<Func<Kullanici, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Kullanici> GetAll()
        {
            throw new NotImplementedException();
        }

        public Kullanici GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Kullanici entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Kullanici> entities)
        {
            throw new NotImplementedException();
        }
    }
}