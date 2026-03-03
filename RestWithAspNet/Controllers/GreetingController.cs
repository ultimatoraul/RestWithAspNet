using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Models;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private static long _counter = 0;
        private static readonly string _template = "Hello {0}!";

        [HttpGet]
        public ActionResult<Greeting> Get([FromQuery] string name = "")
        {
            var id = Interlocked.Increment(ref _counter);
            var content = string.Format(_template, name);
            return Ok(new Greeting(id, content));
        }
    }
}
