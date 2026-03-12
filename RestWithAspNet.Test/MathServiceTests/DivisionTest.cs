using RestWithAspNet.Domain.Services;

namespace RestWithAspNet.xUnit.MathServiceTests
{
    public class DivisionTest
    {
        private readonly MathService _service;

        public DivisionTest()
        {
            _service = new MathService();
        }

        [Fact]
        public void Div_WithValidPositiveNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 100m;
            decimal secondNumber = 20m;
            decimal expectedResult = 5m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Div_WithDivisionByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            decimal firstNumber = 100m;
            decimal secondNumber = 0m;

            // Act & Assert
            var exception = Assert.Throws<DivideByZeroException>(() => _service.Div(firstNumber, secondNumber));
            Assert.Equal("Division bt zero is not allowed.", exception.Message);
        }

        [Fact]
        public void Div_WithDecimalNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 10.5m;
            decimal secondNumber = 2.5m;
            decimal expectedResult = 4.2m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Div_WithNegativeNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = -100m;
            decimal secondNumber = 20m;
            decimal expectedResult = -5m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Div_WithBothNegative_ReturnsPositiveValue()
        {
            // Arrange
            decimal firstNumber = -100m;
            decimal secondNumber = -20m;
            decimal expectedResult = 5m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Div_WithZeroAsNumerator_ReturnsZero()
        {
            // Arrange
            decimal firstNumber = 0m;
            decimal secondNumber = 50m;
            decimal expectedResult = 0m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Div_WithOne_ReturnsTheNumerator()
        {
            // Arrange
            decimal firstNumber = 42m;
            decimal secondNumber = 1m;
            decimal expectedResult = 42m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Div_WithLargeNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 1000000m;
            decimal secondNumber = 1000m;
            decimal expectedResult = 1000m;

            // Act
            var result = _service.Div(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
