using Moq;
using RestWithAspNet.Controllers;
using RestWithAspNet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.xUnit.MathControllerTests
{
    public class SquareRootTest
    {
        private readonly Mock<IMathService> _mockMathService;
        private readonly MathController _controller;

        public SquareRootTest()
        {
            _mockMathService = new Mock<IMathService>();
            _controller = new MathController(_mockMathService.Object);
        }

        [Fact]
        public void GetSquareRoot_WithValidPositiveNumber_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string number = "25";
            double expectedResult = 5;
            _mockMathService.Setup(s => s.SquareRoot(25m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSquareRoot(number);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (double)okResult.Value!);
            _mockMathService.Verify(s => s.SquareRoot(It.IsAny<decimal>()), Times.Once);
        }

        [Fact]
        public void GetSquareRoot_WithZero_ReturnsOkResultWithZero()
        {
            // Arrange
            string number = "0";
            double expectedResult = 0;
            _mockMathService.Setup(s => s.SquareRoot(0m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSquareRoot(number);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (double)okResult.Value!);
        }

        [Fact]
        public void GetSquareRoot_WithDecimalNumber_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string number = "16.0";
            double expectedResult = 4;
            _mockMathService.Setup(s => s.SquareRoot(16.0m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSquareRoot(number);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (double)okResult.Value!);
        }

        [Fact]
        public void GetSquareRoot_WithNegativeNumber_ReturnsBadRequest()
        {
            // Arrange
            string number = "-9";
            _mockMathService.Setup(s => s.SquareRoot(-9m))
                .Throws(new ArgumentOutOfRangeException("Cannot calculate the square root of a negative number."));

            // Act
            var result = _controller.GetSquareRoot(number);

            // Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }

        [Fact]
        public void GetSquareRoot_WithNonNumericNumber_ReturnsBadRequest()
        {
            // Act & Assert
            var result = _controller.GetSquareRoot("abc");
            var badResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            Assert.NotNull(badResult.Value);
        }

        [Fact]
        public void GetSquareRoot_WithLargeNumber_ReturnsOkResultWithCorrectValue()
        {
            // Arrange
            string number = "144";
            double expectedResult = 12;
            _mockMathService.Setup(s => s.SquareRoot(144m)).Returns(expectedResult);

            // Act
            var result = _controller.GetSquareRoot(number);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(expectedResult, (double)okResult.Value!);
        }
    }
}
