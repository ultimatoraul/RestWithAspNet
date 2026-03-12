using Moq;
using RestWithAspNet.Controllers;
using RestWithAspNet.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.xUnit.MathControllerTests
{
    public class MultiplicationTest
    {
        private readonly Mock<IMathService> _mockMathService;
        private readonly MathController _controller;

        public MultiplicationTest()
        {
            _mockMathService = new Mock<IMathService>();
            _controller = new MathController(_mockMathService.Object);
        }

        [Fact]
        public void GetMultiply_WithValidPositiveNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "10";
            string secondNumber = "20";
            decimal expectedResult = 200;
            _mockMathService.Setup(s => s.Multi(10m, 20m)).Returns(expectedResult);

            // Act
            var result = _controller.GetMultiplication(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
            _mockMathService.Verify(s => s.Multi(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void GetMultiply_WithZero_ReturnsOkResultWithZero()
        {
            // Arrange
            string firstNumber = "10";
            string secondNumber = "0";
            decimal expectedResult = 0;
            _mockMathService.Setup(s => s.Multi(10m, 0m)).Returns(expectedResult);

            // Act
            var result = _controller.GetMultiplication(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetMultiply_WithNegativeNumbers_ReturnsOkResultWithPositiveValue()
        {
            // Arrange
            string firstNumber = "-10";
            string secondNumber = "-5";
            decimal expectedResult = 50;
            _mockMathService.Setup(s => s.Multi(-10m, -5m)).Returns(expectedResult);

            // Act
            var result = _controller.GetMultiplication(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetMultiply_WithDecimalNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "2.5";
            string secondNumber = "4.2";
            decimal expectedResult = 10.5m;
            _mockMathService.Setup(s => s.Multi(2.5m, 4.2m)).Returns(expectedResult);

            // Act
            var result = _controller.GetMultiplication(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetMultiply_WithNonNumericNumber_ReturnsBadRequest()
        {
            // Act & Assert
            var result = _controller.GetMultiplication("10", "abc");
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }
    }
}
