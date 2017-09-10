using Example.Models;
using Example.Services.Tests.Fakes;

namespace Example.Services.Tests.Factories
{
    internal static class HorseFactory
    {
        public static Horse Create(FakeHorseRepository fakeRepository, int id = 1, string name = "Ed")
        {
            var horse = new Horse
            {
                Id = id,
                Name = name,
            };

            fakeRepository.Horses.Add(horse);

            return horse;
        }

        public static Horse WithColor(this Horse horse)
        {
            horse.Color = new Color
            {
                Id = 1,
                Name = "Brown"
            };

            return horse;
        }
    }
}