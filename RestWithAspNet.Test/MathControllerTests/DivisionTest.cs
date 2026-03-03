using Moq;
using RestWithAspNet.Controllers;
using RestWithAspNet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.xUnit.MathControllerTests
{
    public class DivisionTest
    {
        private readonly Mock<IMathService> _mockMathService;
        private readonly MathController _controller;

        public DivisionTest()
        {
            _mockMathService = new Mock<IMathService>();
            _controller = new MathController(_mockMathService.Object);
        }

        [Fact]
        public void GetDivision_WithValidPositiveNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "100";
            string secondNumber = "20";
            decimal expectedResult = 5;
            _mockMathService.Setup(s => s.Div(100m, 20m)).Returns(expectedResult);

            // Act
            var result = _controller.GetDivision(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
            _mockMathService.Verify(s => s.Div(It.IsAny<decimal>(), It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void GetDivision_WithDivisionByZero_ReturnsBadRequest()
        {
            // Arrange
            string firstNumber = "100";
            string secondNumber = "0";
            _mockMathService.Setup(s => s.Div(100m, 0m))
                .Throws(new DivideByZeroException("Division bt zero is not allowed."));

            // Act
            var result = _controller.GetDivision(firstNumber, secondNumber);

            // Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }

        [Fact]
        public void GetDivision_WithDecimalNumbers_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string firstNumber = "10.5";
            string secondNumber = "2.5";
            decimal expectedResult = 4.2m;
            _mockMathService.Setup(s => s.Div(10.5m, 2.5m)).Returns(expectedResult);

            // Act
            var result = _controller.GetDivision(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetDivision_WithNegativeNumbers_ReturnsOkResultWithNegativeValue()
        {
            // Arrange
            string firstNumber = "-100";
            string secondNumber = "20";
            decimal expectedResult = -5;
            _mockMathService.Setup(s => s.Div(-100m, 20m)).Returns(expectedResult);

            // Act
            var result = _controller.GetDivision(firstNumber, secondNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (decimal)okResult.Value!);
        }

        [Fact]
        public void GetDivision_WithNonNumericNumber_ReturnsBadRequest()
        {
            // Act & Assert
            var result = _controller.GetDivision("100", "abc");
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }
    }
}
