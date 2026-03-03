using RestWithAspNet.Services;

namespace RestWithAspNet.xUnit.MathServiceTests
{
    public class SumTest
    {
        private readonly MathService _service;

        public SumTest()
        {
            _service = new MathService();
        }

        [Fact]
        public void Sum_WithValidPositiveNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 10m;
            decimal secondNumber = 20m;
            decimal expectedResult = 30m;

            // Act
            var result = _service.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sum_WithNegativeNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = -10m;
            decimal secondNumber = -20m;
            decimal expectedResult = -30m;

            // Act
            var result = _service.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sum_WithDecimalNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 10.5m;
            decimal secondNumber = 20.3m;
            decimal expectedResult = 30.8m;

            // Act
            var result = _service.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sum_WithZero_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 0m;
            decimal secondNumber = 50m;
            decimal expectedResult = 50m;

            // Act
            var result = _service.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sum_WithBothZero_ReturnsZero()
        {
            // Arrange
            decimal firstNumber = 0m;
            decimal secondNumber = 0m;
            decimal expectedResult = 0m;

            // Act
            var result = _service.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sum_WithMixedPositiveAndNegative_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 50m;
            decimal secondNumber = -30m;
            decimal expectedResult = 20m;

            // Act
            var result = _service.Sum(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
