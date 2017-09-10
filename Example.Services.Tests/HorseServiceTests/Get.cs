using Example.Services.Tests.Factories;
using Example.Services.Tests.Fakes;
using Xunit;

namespace Example.Services.Tests.HorseServiceTests
{
    [Trait("Category", "HorseService")]
    public class Get
    {
        private readonly FakeHorseRepository _fakeRepository;

        public Get()
        {
            _fakeRepository = new FakeHorseRepository();
        }

        [Theory]
        [InlineData(1, "Ed")]
        [InlineData(2, "War Admiral")]
        [InlineData(3, "Suzie")]
        public void ItReturnsHorseFromRepository(int id, string name)
        {
            // Arrange
            var expectedHorse = HorseFactory.Create(_fakeRepository, id, name).WithColor();
            var service = new HorseService(_fakeRepository);

            // Act
            var actualHorse = service.Get(expectedHorse.Id);

            // Assert
            Assert.True(_fakeRepository.GetCalled);
            Assert.Equal(expectedHorse.Id, actualHorse.Id);
            Assert.Equal(expectedHorse.Name, actualHorse.Name);
        }

        [Fact]
        public void GivenHorseNotFoundThenNullHorse()
        {
            // Arrange
            var service = new HorseService(_fakeRepository);

            // Act
            var actualHorse = service.Get(-1);

            // Assert
            Assert.Null(actualHorse);
        }
    }
}