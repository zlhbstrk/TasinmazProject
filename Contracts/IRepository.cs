using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tasinmaz.Contracts
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id); //bul-filtele gibi düşündüm
        IEnumerable<T> GetAll(); //listele
        // IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity); //ekle
        // void AddRange(IEnumerable<T> entities);
        void Remove(T entity); //sil
        // void RemoveRange(IEnumerable<T> entities);
    }
}