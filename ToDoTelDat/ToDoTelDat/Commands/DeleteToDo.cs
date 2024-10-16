using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Commands
{
    public record DeleteToDoCommand(int ToDoId) : IRequest<bool>;

    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand, bool>
    {
        private readonly ToDoContext _dbContext;

        public DeleteToDoCommandHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoToDelete = await _dbContext.ToDoes.FirstOrDefaultAsync(t => t.ToDoId == request.ToDoId);

            if(toDoToDelete is null)
                return false;

            _dbContext.ToDoes.Remove(toDoToDelete);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return true;
        }
    }
}
