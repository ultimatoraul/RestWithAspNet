namespace RestWithAspNet.Domain.Interfaces
{
    public interface IMathService
    {
        decimal Sum(decimal firstNumber, decimal secondNumber);
        decimal Sub(decimal firstNumber, decimal secondNumber);
        decimal Div(decimal firstNumber, decimal secondNumber);
        decimal Multi(decimal firstNumber, decimal secondNumber);
        double SquareRoot(decimal number);
    }
}
