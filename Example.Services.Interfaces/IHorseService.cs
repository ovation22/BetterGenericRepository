using System.Collections.Generic;
using Example.DTO.Horse;

namespace Example.Services.Interfaces
{
    public interface IHorseService
    {
        IEnumerable<HorseSummary> GetAll();
        HorseDetail Get(int id);
        void Create(HorseCreate horse);
    }
}