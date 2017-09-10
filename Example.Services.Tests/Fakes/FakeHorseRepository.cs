using System.Collections.Generic;
using System.Linq;
using Example.Models;
using Example.Repository.Interfaces;

namespace Example.Services.Tests.Fakes
{
    internal class FakeHorseRepository : IRepository<Horses>
    {
        public List<Horses> Horses = new List<Horses>();

        public bool GetCalled { get; set; }
        public bool GetAllCalled { get; private set; }

        public IEnumerable<Horses> GetAll()
        {
            GetAllCalled = true;
            return Horses.AsQueryable();
        }

        public Horses Get(int id)
        {
            GetCalled = true;
            return Horses.Find(x => x.Id == id);
        }
    }
}