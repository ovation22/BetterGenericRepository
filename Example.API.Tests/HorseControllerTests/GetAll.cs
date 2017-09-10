using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;
using Example.API.Controllers;
using Example.DTO;
using Example.DTO.Horse;
using Example.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Example.API.Tests.HorseControllerTests
{
    [Collection("HorseController")]
    [Trait("Category", "HorseController")]
    public class GetAll
    {
        private readonly HorsesController _controller;
        private static Mock<IHorseService> _horseServiceMock;
        private readonly List<HorseSummary> _horses;

        public GetAll()
        {
            _horses = new List<HorseSummary>
            {
                new HorseSummary
                {
                    Name = "test"
                }
            };

            _horseServiceMock = new Mock<IHorseService>();
            _horseServiceMock.Setup(x => x.GetAll())
                .Returns(() => _horses);

            _controller = new HorsesController(_horseServiceMock.Object);
        }

        [Fact]
        public void ItReturnsOkObjectResult()
        {
            // Arrange
            // Act
            var result = _controller.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void ItReturnsCollectionOfHorseSummary()
        {
            // Arrange
            // Act
            var result = _controller.Get() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.Value);
            Assert.IsAssignableFrom<IEnumerable<HorseSummary>>(result.Value);
        }

        [Fact]
        public void ItCallsGetAllServiceOnce()
        {
            // Arrange
            // Act
            _controller.Get();

            // Assert
            _horseServiceMock.Verify(mock => mock.GetAll(), Times.Once());
        }

        [Fact]
        public void GivenHorseServiceThenResultsReturned()
        {
            // Arrange
            // Act
            var result = _controller.Get() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            var horses = ((IEnumerable<HorseSummary>) result.Value).ToList();
            Assert.Equal(_horses, horses);
        }
    }
}