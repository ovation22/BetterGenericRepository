using System.Collections.Generic;

namespace Example.Repository.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(int id);
    }
}
