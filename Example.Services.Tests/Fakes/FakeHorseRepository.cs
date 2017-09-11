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
        public bool AddCalled { get; set; }
        public bool SaveCalled { get; set; }
        public Horse AddCalledWith { get; set; }

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
            AddCalled = true;
            AddCalledWith = entity;
        }

        public void Save()
        {
            SaveCalled = true;
        }

        public IRepository<Horse> Include(Expression<Func<Horse, object>> path)
        {
            return this;
        }
    }
}