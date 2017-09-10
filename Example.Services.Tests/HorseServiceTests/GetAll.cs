using System.Collections.Generic;
using System.Linq;
using Example.DTO.Horse;
using Example.Services.Tests.Factories;
using Example.Services.Tests.Fakes;
using Xunit;

namespace Example.Services.Tests.HorseServiceTests
{
    [Collection("HorseService")]
    [Trait("Category", "HorseService")]
    [Trait("Category", "HorseSummary")]
    public class GetAll
    {
        private readonly HorseService _horseService;
        private readonly FakeHorseRepository _fakeRepository;

        public GetAll()
        {
            _fakeRepository = new FakeHorseRepository();
            HorseFactory.Create(_fakeRepository);

            _horseService = new HorseService(_fakeRepository);
        }

        [Fact]
        public void ItReturnsCollectionOfHorseSummary()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            Assert.NotNull(horses);
            Assert.IsAssignableFrom<IEnumerable<HorseSummary>>(horses);
        }

        [Fact]
        public void ItReturnsAllHorses()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll();

            // Assert
            Assert.NotNull(horses);
            Assert.IsAssignableFrom<IEnumerable<HorseSummary>>(horses);
            Assert.Equal(_fakeRepository.Horses.Count, horses.Count());
        }

        [Fact]
        public void ItReturnsAllHorsesWithProperties()
        {
            // Arrange
            // Act
            var horses = _horseService.GetAll().ToList();

            // Assert
            Assert.NotNull(horses);
            Assert.IsAssignableFrom<IEnumerable<HorseSummary>>(horses);

            for (var i = 0; i < horses.Count; i++)
            {
                Assert.NotNull(_fakeRepository.Horses[i].Name);
                Assert.Equal(_fakeRepository.Horses[i].Name, horses[i].Name);
                Assert.NotNull(_fakeRepository.Horses[i].Id);
                Assert.Equal(_fakeRepository.Horses[i].Id, horses[i].Id);
            }
        }
    }
}