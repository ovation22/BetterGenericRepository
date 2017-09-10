using Moq;
using Xunit;
using Example.API.Controllers;
using Example.DTO.Horse;
using Example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Tests.HorseControllerTests
{
    [Collection("HorseController")]
    [Trait("Category", "HorseController")]
    public class Get
    {
        private readonly HorsesController _controller;
        private static Mock<IHorseService> _horseServiceMock;
        private readonly HorseDetail _horse;

        public Get()
        {
            _horse = new HorseDetail
            {
                Name = "Horse"
            };

            _horseServiceMock = new Mock<IHorseService>();
            _horseServiceMock.Setup(x => x.Get(It.IsAny<int>()))
                .Returns(() => _horse);
            _horseServiceMock.Setup(x => x.Get(-1))
                .Returns(() => null);

            _controller = new HorsesController(_horseServiceMock.Object);
        }

        [Fact]
        public void ItAcceptsInteger()
        {
            // Arrange
            // Act
            _controller.Get(1);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.Get(1);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItReturnsHorseDetail()
        {
            // Arrange
            // Act
            var result = _controller.Get(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsType<HorseDetail>(result.Value);
        }

        [Fact]
        public void ItCallsGetServiceOnce()
        {
            // Arrange
            // Act
            _controller.Get(1);

            // Assert
            _horseServiceMock.Verify(mock => mock.Get(It.IsAny<int>()), Times.Once());
        }

        [Fact]
        public void ItCallsGetServiceWithProvidedId()
        {
            // Arrange
            const int id = 1;

            // Act
            _controller.Get(id);

            // Assert
            _horseServiceMock.Verify(mock => mock.Get(id), Times.Once());
        }

        [Fact]
        public void GivenHorseServiceThenResultsReturned()
        {
            // Arrange
            // Act
            var result = _controller.Get(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var horse = ((HorseDetail) result.Value);
            Assert.Equal(_horse, horse);
        }

        [Fact]
        public void GivenHorseNotFoundExceptionThenNotFoundObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.Get(-1);

            // Assert
            Assert.IsAssignableFrom<NotFoundObjectResult>(result);
        }

        [Fact]
        public void GivenHorseNotFoundExceptionThenMessageReturned()
        {
            // Arrange
            // Act
            var result = _controller.Get(-1) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Horse Not Found", result.Value);
        }
    }
}