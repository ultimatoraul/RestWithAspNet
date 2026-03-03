using Microsoft.AspNetCore.Mvc;

namespace RestWithAspNet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public record UserDto;

        [Route("v1/users/")]
        [HttpGet]
        public ActionResult<UserDto> Get(int id)
        {
            //UserService User_Service = new UserService();
            //UserDto userDto = User_Service.GetUser(id);
            UserDto userDto = new UserDto();
            return Ok(userDto);
        }
    }
}
