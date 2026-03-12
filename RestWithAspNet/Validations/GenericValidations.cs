using RestWithAspNet.Utils;

namespace RestWithAspNet.Validations
{
    public class GenericValidations
    {
        static internal void IdArgument(string id)
        {
            if (!NumberHelper.IsNumeric(id))
                throw new ArgumentException($"The Id ({id}) must be numeric");
        }
    }
}
