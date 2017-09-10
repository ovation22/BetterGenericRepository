using System;
using System.Linq;
using System.Linq.Expressions;

namespace Example.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        T Get(Func<T, bool> predicate);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Save();
        IRepository<T> Include(Expression<Func<T, object>> path);
    }
}