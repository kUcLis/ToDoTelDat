using MediatR;
using ToDoTelDat.Entities;
using ToDoTelDat.Models;

namespace ToDoTelDat.Commands
{
    public record CreateToDoCommand(ToDo ToDo) : IRequest<ToDo>;

    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDo>
    {
        private readonly ToDoContext _dbContext;

        public CreateToDoCommandHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ToDo> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var newToDo = new ToDo 
            {
                TaskName = request.ToDo.TaskName,
                Description = request.ToDo.Description,
                StartDate = request.ToDo.StartDate.AddHours(2),
                UserId = request.ToDo.UserId,
            };
            await _dbContext.AddAsync(newToDo, CancellationToken.None);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return newToDo;

        }
    }
}
