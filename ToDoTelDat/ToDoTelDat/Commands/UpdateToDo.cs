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
            _dbContext.Update(request.ToDo);
            await _dbContext.SaveChangesAsync(CancellationToken.None);
            
            return request.ToDo;
        }
    }
}
