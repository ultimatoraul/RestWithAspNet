using RestWithAspNet.Services;

namespace RestWithAspNet.xUnit.MathServiceTests
{
    public class MultiplicationTest
    {
        private readonly MathService _service;

        public MultiplicationTest()
        {
            _service = new MathService();
        }

        [Fact]
        public void Multi_WithValidPositiveNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 10m;
            decimal secondNumber = 20m;
            decimal expectedResult = 200m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multi_WithZero_ReturnsZero()
        {
            // Arrange
            decimal firstNumber = 10m;
            decimal secondNumber = 0m;
            decimal expectedResult = 0m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multi_WithNegativeNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = -10m;
            decimal secondNumber = -5m;
            decimal expectedResult = 50m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multi_WithDecimalNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 2.5m;
            decimal secondNumber = 4.2m;
            decimal expectedResult = 10.5m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multi_WithMixedPositiveAndNegative_ReturnsNegativeValue()
        {
            // Arrange
            decimal firstNumber = 10m;
            decimal secondNumber = -5m;
            decimal expectedResult = -50m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multi_WithOne_ReturnsTheOtherNumber()
        {
            // Arrange
            decimal firstNumber = 1m;
            decimal secondNumber = 42m;
            decimal expectedResult = 42m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Multi_WithLargeNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 1000m;
            decimal secondNumber = 2000m;
            decimal expectedResult = 2000000m;

            // Act
            var result = _service.Multi(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
