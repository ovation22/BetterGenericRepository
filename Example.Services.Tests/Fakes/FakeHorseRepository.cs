using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Example.Models;
using Example.Repositories.Interfaces;

namespace Example.Services.Tests.Fakes
{
    internal class FakeHorseRepository : IRepository<Horse>
    {
        public List<Horse> Horses = new List<Horse>();

        public bool GetCalled { get; set; }
        public bool GetAllCalled { get; private set; }

        public Horse Get(Func<Horse, bool> predicate)
        {
            GetCalled = true;
            return Horses.SingleOrDefault(predicate);
        }

        public IQueryable<Horse> GetAll()
        {
            GetAllCalled = true;
            return Horses.AsQueryable();
        }

        public void Add(Horse entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IRepository<Horse> Include(Expression<Func<Horse, object>> path)
        {
            return this;
        }
    }
}