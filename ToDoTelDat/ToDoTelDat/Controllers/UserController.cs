using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTelDat.Commands;

namespace ToDoTelDat.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpPost]
        [Route("create/{userName}")]
        public async Task<IActionResult> CreateUser([FromRoute] string userName)
        {
            var response = await _mediatr.Send(new CreateUserCommand(userName));
            return Ok(response);
        }
    }
}
