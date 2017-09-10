using Example.Models;
using Example.Services.Tests.Fakes;

namespace Example.Services.Tests.Factories
{
    internal static class HorseFactory
    {
        public static Horses Create(FakeHorseRepository fakeRepository, int id = 1, string name = "Ed")
        {
            var horse = new Horses
            {
                Id = id,
                Name = name,
            };

            fakeRepository.Horses.Add(horse);

            return horse;
        }
    }
}