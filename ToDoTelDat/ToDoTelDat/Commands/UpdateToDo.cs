using MediatR;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Commands
{
    public record UpdateToDoCommand(ToDo ToDo) : IRequest<ToDo>;

    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand, ToDo>
    {
        private readonly ToDoContext _dbContext;

        public UpdateToDoCommandHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ToDo> Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoToUpdate = new ToDo
            {
                ToDoId = request.ToDo.ToDoId,
                TaskName = request.ToDo.TaskName,
                Description = request.ToDo.Description,
                StartDate = request.ToDo.StartDate.AddHours(2),
                UserId = request.ToDo.UserId,
            };

            _dbContext.Update(toDoToUpdate);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            
            return toDoToUpdate;
        }
    }
}
