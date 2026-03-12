using RestWithAspNet.Domain.Interfaces;

namespace RestWithAspNet.Domain.Services
{
    public class MathService : IMathService
    {
        public decimal Sum(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
        }

        public decimal Sub(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber - secondNumber;
        }

        public decimal Div(decimal firstNumber, decimal secondNumber)
        {
            if (secondNumber == 0)
                throw new DivideByZeroException("Division bt zero is not allowed.");
            return firstNumber / secondNumber;
        }

        public decimal Multi(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }

        public double SquareRoot(decimal number)
        {
            if (number < 0)
                throw new ArgumentOutOfRangeException("Cannot calculate the square root of a negative number.");
            return Math.Sqrt((double)number);
        }
    }
}
