﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoTelDat.Commands;
using ToDoTelDat.Entities;

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
        [HttpPost]
        public async Task<IActionResult> CreateToDo(ToDo toDo)
        {
            var response = await _mediatr.Send(new CreateToDoCommand(toDo));
            return Ok(response);
        }
    }
}
