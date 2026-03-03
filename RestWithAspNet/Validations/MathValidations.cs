using RestWithAspNet.Utils;

namespace RestWithAspNet.Validations
{
    public class MathValidations
    {
        static internal void NumericArgument(string number)
        {
            if (!NumberHelper.IsNumeric(number))
                throw new ArgumentException($"The number ({number}) isn't numeric");
        }

        static internal void NumericArguments(string firstNumber, string secondNumber)
        {
            if (!NumberHelper.IsNumeric(firstNumber))
                throw new ArgumentException($"The firstNumber ({firstNumber}) isn't numeric");

            if (!NumberHelper.IsNumeric(secondNumber))
                throw new ArgumentException($"The secondNumber ({secondNumber}) isn't numeric");
        }
    }
}
