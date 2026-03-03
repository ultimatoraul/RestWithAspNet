using Moq;
using RestWithAspNet.Controllers;
using RestWithAspNet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.xUnit.MathControllerTests
{
    public class SubtractionTest
    {
        private readonly Mock<IMathService> _mockMathService;
        private readonly MathController _controller;

        public SubtractionTest()
        {
            _mockMathService = new Mock<IMathService>();
            _controller = new MathController(_mockMathService.Object);
        }

        [Fact]
        public void GetSub_WithValidPositiveNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "50";
            string secondNumber = "20";
            decimal expectedResult = 30;
            _mockMathService.Setup(s => s.Sub(50m, 20m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSub(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
            _mockMathService.Verify(s => s.Sub(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void GetSub_WithNegativeResult_ReturnsOkResultWithNegativeValue()
        {
            // Arrange
            string firstNumber = "10";
            string secondNumber = "50";
            decimal expectedResult = -40;
            _mockMathService.Setup(s => s.Sub(10m, 50m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSub(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetSub_WithNonNumericFirstNumber_ReturnsBadRequest()
        {
            // Act & Assert
            var result = _controller.GetSub("abc", "20");
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }

        [Fact]
        public void GetSub_WithDecimalNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "25.5";
            string secondNumber = "10.3";
            decimal expectedResult = 15.2m;
            _mockMathService.Setup(s => s.Sub(25.5m, 10.3m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSub(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }
    }
}
