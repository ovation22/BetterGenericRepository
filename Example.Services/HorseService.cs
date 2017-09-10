using System.Collections.Generic;
using System.Linq;
using Example.DTO.Horse;
using Example.Models;
using Example.Repositories.Interfaces;
using Example.Services.Interfaces;

namespace Example.Services
{
    public class HorseService : IHorseService
    {
        private readonly IRepository<Horse> _repository;

        public HorseService(IRepository<Horse> repository)
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
            var horse = _repository.Include(x => x.Color).Get(x => x.Id == id);
            
            return horse == null ? null : Map(horse);
        }

        public void Create(HorseCreate horse)
        {
            var horseEntity = new Horse
            {
                Name = horse.Name,
                ColorId = horse.ColorId,
                RaceWins = horse.Win,
                RacePlace = horse.Place,
                RaceShow = horse.Show,
                RaceStarts = horse.Starts,
                SireId = horse.SireId,
                DamId = horse.DamId
            };

            _repository.Add(horseEntity);
            _repository.Save();
        }

        private static HorseDetail Map(Horse horse)
        {
            return new HorseDetail
            {
                Id = horse.Id,
                Name = horse.Name,
                Starts = horse.RaceStarts,
                Win = horse.RaceWins,
                Place = horse.RacePlace,
                Show = horse.RaceShow,
                Earnings = horse.Earnings,
                Color = horse.Color.Name
            };
        }
    }
}