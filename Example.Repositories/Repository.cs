using System;
using System.Collections.Generic;
using Example.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace Example.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        protected readonly DbContext Context;
        private readonly IList<Expression<Func<T, object>>> _modifiers;

        public Repository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<T>();
            _modifiers = new List<Expression<Func<T, object>>>();
        }

        protected IQueryable<T> DbSet
        {
            get
            {
                return _modifiers.Aggregate((IQueryable<T>) _dbSet, (current, include) =>
                    current.Include(include));
            }
        }

        public T Get(Func<T, bool> predicate)
        {
            return DbSet.SingleOrDefault(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public IRepository<T> Include(Expression<Func<T, object>> path)
        {
            _modifiers.Add(path);

            return this;
        }
    }
}