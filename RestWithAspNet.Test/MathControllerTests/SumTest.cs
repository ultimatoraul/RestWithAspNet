using Moq;
using RestWithAspNet.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Controllers;

namespace RestWithAspNet.xUnit.MathControllerTests
{
    public class SumTest
    {
        private readonly Mock<IMathService> _mockMathService;
        private readonly MathController _controller;

        public SumTest()
        {
            _mockMathService = new Mock<IMathService>();
            _controller = new MathController(_mockMathService.Object);
        }

        [Fact]
        public void GetSum_WithValidPositiveNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "10";
            string secondNumber = "20";
            decimal expectedResult = 30;
            _mockMathService.Setup(s => s.Sum(10m, 20m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSum(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
            _mockMathService.Verify(s => s.Sum(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void GetSum_WithNegativeNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "-10";
            string secondNumber = "-20";
            decimal expectedResult = -30;
            _mockMathService.Setup(s => s.Sum(-10m, -20m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSum(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetSum_WithDecimalNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "10.5";
            string secondNumber = "20.3";
            decimal expectedResult = 30.8m;
            _mockMathService.Setup(s => s.Sum(10.5m, 20.3m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSum(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetSum_WithNonNumericFirstNumber_ReturnsBadRequest()
        {
            // Act & Assert
            var result = _controller.GetSum("abc", "20");
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }

        [Fact]
        public void GetSum_WithNonNumericSecondNumber_ReturnsBadRequest()
        {
            // Act & Assert
            var result = _controller.GetSum("10", "xyz");
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }

        [Fact]
        public void GetSum_WithZero_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "0";
            string secondNumber = "50";
            decimal expectedResult = 50;
            _mockMathService.Setup(s => s.Sum(0m, 50m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSum(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }
    }
}
