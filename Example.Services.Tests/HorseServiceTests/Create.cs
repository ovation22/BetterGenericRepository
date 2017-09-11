using Example.DTO.Horse;
using Example.Services.Tests.Fakes;
using Xunit;

namespace Example.Services.Tests.HorseServiceTests
{
    [Trait("Category", "HorseService")]
    public class Create
    {
        private readonly FakeHorseRepository _fakeRepository;

        public Create()
        {
            _fakeRepository = new FakeHorseRepository();
        }

        [Fact]
        public void ItCallsRepositoryAdd()
        {
            // Arrange
            var service = new HorseService(_fakeRepository);

            // Act
            service.Create(new HorseCreate());

            // Assert
            Assert.True(_fakeRepository.AddCalled);
        }

        [Fact]
        public void ItCallsRepositorySave()
        {
            // Arrange
            var service = new HorseService(_fakeRepository);

            // Act
            service.Create(new HorseCreate());

            // Assert
            Assert.True(_fakeRepository.SaveCalled);
        }

        [Fact]
        public void ItMapsHorse()
        {
            // Arrange
            var service = new HorseService(_fakeRepository);
            var horse = new HorseCreate
            {
                Name = "Test",
                ColorId = 1,
                Win = 2,
                Place = 3,
                Show = 4,
                Starts = 5,
                SireId = 6,
                DamId = 7
            };

            // Act
            service.Create(horse);
            var actual = _fakeRepository.AddCalledWith;

            // Assert
            Assert.Equal(horse.Name, actual.Name);
            Assert.Equal(horse.ColorId, actual.ColorId);
            Assert.Equal(horse.Win, actual.RaceWins);
            Assert.Equal(horse.Place, actual.RacePlace);
            Assert.Equal(horse.Show, actual.RaceShow);
            Assert.Equal(horse.Starts, actual.RaceStarts);
            Assert.Equal(horse.SireId, actual.SireId);
            Assert.Equal(horse.DamId, actual.DamId);
        }
    }
}