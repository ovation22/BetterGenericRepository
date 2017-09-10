using System.Collections.Generic;
using System.Linq;
using Example.DTO;
using Example.Models;
using Example.Repository.Interfaces;
using Example.Services.Interfaces;

namespace Example.Services
{
    public class HorseService : IHorseService
    {
        private readonly IRepository<Horses> _repository;

        public HorseService(IRepository<Horses> repository)
        {
            _repository = repository;
        }

        public IEnumerable<HorseSummary> GetAll()
        {
            return _repository.GetAll().Select(x => new HorseSummary
            {
                Id = x.Id,
                Name = x.Name
            });            
        }

        public HorseDetail Get(int id)
        {
            var horse = _repository.Get(id);

            return horse != null ? new HorseDetail
            {
                Id = horse.Id,
                Name = horse.Name
            } : null;
        }
    }
}
