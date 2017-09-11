using System.Linq;
using Example.API.Attributes;
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
    public class Create
    {
        private readonly HorsesController _controller;
        private static Mock<IHorseService> _horseServiceMock;
        private readonly HorseCreate _horse;

        public Create()
        {
            _horse = new HorseCreate
            {
                Name = "Horse"
            };

            _horseServiceMock = new Mock<IHorseService>();
            _horseServiceMock.Setup(x => x.Create(It.IsAny<HorseCreate>()))
                .Verifiable();

            _controller = new HorsesController(_horseServiceMock.Object);
        }

        [Fact]
        public void ItAcceptsHorseCreate()
        {
            // Arrange
            // Act
            _controller.Create(_horse);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.Create(_horse);

            // Assert
            Assert.IsType<AcceptedResult>(result);
        }

        [Fact]
        public void ItCallsCreateServiceOnce()
        {
            // Arrange
            // Act
            _controller.Create(_horse);

            // Assert
            _horseServiceMock.Verify(mock => mock.Create(It.IsAny<HorseCreate>()), Times.Once());
        }

        [Fact]
        public void ItCallsCreateServiceWithProvidedHorse()
        {
            // Arrange
            // Act
            _controller.Create(_horse);

            // Assert
            _horseServiceMock.Verify(mock => mock.Create(_horse), Times.Once());
        }

        [Fact]
        public void ItHasValidateModelAttribute()
        {
            // Arrange
            // Act
            var method = typeof(HorsesController).GetMethods()
                .SingleOrDefault(x => x.Name == nameof(HorsesController.Create));

            var attribute = method?.GetCustomAttributes(typeof(ValidateModelAttribute), true)
                .Single() as ValidateModelAttribute;

            // Assert
            Assert.NotNull(attribute);
        }
    }
}