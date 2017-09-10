using System.Collections.Generic;
using Example.DTO;

namespace Example.Services.Interfaces
{
    public interface IHorseService    
    {
        IEnumerable<HorseSummary> GetAll();
        HorseDetail Get(int id);
    }
}
