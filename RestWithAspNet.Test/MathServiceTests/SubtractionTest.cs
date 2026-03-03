using RestWithAspNet.Services;

namespace RestWithAspNet.xUnit.MathServiceTests
{
    public class SubtractionTest
    {
        private readonly MathService _service;

        public SubtractionTest()
        {
            _service = new MathService();
        }

        [Fact]
        public void Sub_WithValidPositiveNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 50m;
            decimal secondNumber = 20m;
            decimal expectedResult = 30m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sub_WithNegativeResult_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 10m;
            decimal secondNumber = 50m;
            decimal expectedResult = -40m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sub_WithDecimalNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = 25.5m;
            decimal secondNumber = 10.3m;
            decimal expectedResult = 15.2m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sub_WithNegativeNumbers_ReturnsCorrectValue()
        {
            // Arrange
            decimal firstNumber = -10m;
            decimal secondNumber = -5m;
            decimal expectedResult = -5m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sub_WithZeroAsFirstNumber_ReturnsNegativeOfSecond()
        {
            // Arrange
            decimal firstNumber = 0m;
            decimal secondNumber = 30m;
            decimal expectedResult = -30m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sub_WithZeroAsSecondNumber_ReturnsFirst()
        {
            // Arrange
            decimal firstNumber = 50m;
            decimal secondNumber = 0m;
            decimal expectedResult = 50m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Sub_WithBothZero_ReturnsZero()
        {
            // Arrange
            decimal firstNumber = 0m;
            decimal secondNumber = 0m;
            decimal expectedResult = 0m;

            // Act
            var result = _service.Sub(firstNumber, secondNumber);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
