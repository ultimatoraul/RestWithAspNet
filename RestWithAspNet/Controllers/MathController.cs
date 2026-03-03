using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Interfaces;
using RestWithAspNet.Utils;
using RestWithAspNet.Validations;

namespace RestWithAspNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController(IMathService service) : ControllerBase
    {
        private readonly IMathService _service = service;

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public ActionResult<decimal> GetSum(string firstNumber, string secondNumber) 
        {
            try
            {
                MathValidations.NumericArguments(firstNumber, secondNumber);

                decimal result = _service.Sum(NumberHelper.StringToDecimal(firstNumber), NumberHelper.StringToDecimal(secondNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public ActionResult<decimal> GetSub(string firstNumber, string secondNumber)
        {
            try
            {
                MathValidations.NumericArguments(firstNumber, secondNumber);

                decimal result = _service.Sub(NumberHelper.StringToDecimal(firstNumber), NumberHelper.StringToDecimal(secondNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("multi/{firstNumber}/{secondNumber}")]
        public ActionResult<decimal> GetMultiplication(string firstNumber, string secondNumber)
        {
            try
            {
                MathValidations.NumericArguments(firstNumber, secondNumber);

                decimal result = _service.Multi(NumberHelper.StringToDecimal(firstNumber), NumberHelper.StringToDecimal(secondNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public ActionResult<decimal> GetDivision(string firstNumber, string secondNumber)
        {
            try
            {
                MathValidations.NumericArguments(firstNumber, secondNumber);

                decimal result = _service.Div(NumberHelper.StringToDecimal(firstNumber), NumberHelper.StringToDecimal(secondNumber));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("square-root/{number}")]
        public ActionResult<double> GetSquareRoot(string number)
        {
            try
            {
                MathValidations.NumericArgument(number);

                double result = _service.SquareRoot(NumberHelper.StringToDecimal(number));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
