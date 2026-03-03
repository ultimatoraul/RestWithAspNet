using RestWithAspNet.Services;

namespace RestWithAspNet.xUnit.MathServiceTests
{
    public class SquareRootTest
    {
        private readonly MathService _service;

        public SquareRootTest()
        {
            _service = new MathService();
        }

        [Fact]
        public void SquareRoot_WithValidPositiveNumber_ReturnsCorrectValue()
        {
            // Arrange
            decimal number = 25m;
            double expectedResult = 5;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SquareRoot_WithZero_ReturnsZero()
        {
            // Arrange
            decimal number = 0m;
            double expectedResult = 0;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SquareRoot_WithDecimalNumber_ReturnsCorrectValue()
        {
            // Arrange
            decimal number = 16.0m;
            double expectedResult = 4;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SquareRoot_WithNegativeNumber_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            decimal number = -9m;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => _service.SquareRoot(number));
            Assert.Equal("Cannot calculate the square root of a negative number.", exception.ParamName == null ? exception.Message : exception.ParamName);
        }

        [Fact]
        public void SquareRoot_WithLargeNumber_ReturnsCorrectValue()
        {
            // Arrange
            decimal number = 144m;
            double expectedResult = 12;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SquareRoot_WithOne_ReturnsOne()
        {
            // Arrange
            decimal number = 1m;
            double expectedResult = 1;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void SquareRoot_WithNonPerfectSquare_ReturnsApproximateValue()
        {
            // Arrange
            decimal number = 2m;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.True(result > 1.4 && result < 1.5, $"Expected result between 1.4 and 1.5, but got {result}");
        }

        [Fact]
        public void SquareRoot_WithVerySmallNumber_ReturnsCorrectValue()
        {
            // Arrange
            decimal number = 0.25m;
            double expectedResult = 0.5;

            // Act
            var result = _service.SquareRoot(number);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
