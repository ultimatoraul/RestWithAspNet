using Microsoft.AspNetCore.Mvc;
using RestWithAspNet.Domain.Interfaces;
using RestWithAspNet.Domain.Models;
using RestWithAspNet.Validations;

namespace RestWithAspNet.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            List<Person> result = _personService.FindAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<Person> Get(long id)
        {
            try
            {
                Person result = _personService.FindById(id);
                if (result == null)
                    return NotFound(new { message = "Person not found" });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("findByName/{name}")]
        public ActionResult<List<Person>> GetByName(string name)
        {
            try
            {
                List<Person> result = _personService.FindByName(name);
                if (result.Count == 0) 
                    return NotFound(new { message = $"No one with the name ({name}) was found." });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person person)
        {
            var createdPerson = _personService.Create(person);
            if (createdPerson == null) 
                return NotFound(new { message = "The person was not created" });

            return Ok(createdPerson);
        }
    }
}
