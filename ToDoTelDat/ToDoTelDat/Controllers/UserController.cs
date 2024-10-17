using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTelDat.Commands;
using ToDoTelDat.Queries;

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

        [HttpGet]
        [Route("{userName}")]
        public async Task<IActionResult> GetByName([FromRoute] string userName)
        {
            var response = await _mediatr.Send(new GetUserByUserNameQuery(userName));
            return Ok(response);
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
