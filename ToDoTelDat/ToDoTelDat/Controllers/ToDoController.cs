using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTelDat.Commands;
using ToDoTelDat.Entities;
using ToDoTelDat.Queries;

namespace ToDoTelDat.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public ToDoController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetByDate(DateTime day, [FromRoute] int userId)
        {
            var response = await _mediatr.Send(new GetByDayQuery(day, userId));

            if(!response.Any())
                return NotFound();

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDo(ToDo toDo)
        {
            var response = await _mediatr.Send(new CreateToDoCommand(toDo));
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDo(ToDo toDo)
        {
            var response = await _mediatr.Send(new UpdateToDoCommand(toDo));
            return Ok(response);
        }

        [HttpDelete]
        [Route("{userId}/{toDoId}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] int userId, [FromRoute] int toDoId)
        {
            var response = await _mediatr.Send(new DeleteToDoCommand(toDoId, userId));
            return Ok(response);
        }
    }
}
