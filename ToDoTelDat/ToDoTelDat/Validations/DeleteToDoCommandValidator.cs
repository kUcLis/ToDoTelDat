using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Commands;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Validations
{
    public class DeleteToDoCommandValidator : AbstractValidator<DeleteToDoCommand>
    {
        public DeleteToDoCommandValidator(ToDoContext dbContext)
        {
            RuleFor(x => x.ToDoId)
            .MustAsync(async (x, cTkn) =>
            {
                return await dbContext.ToDoes.AnyAsync(t => t.ToDoId == x, cTkn);
            })
            .WithName(nameof(ToDo.ToDoId))
            .WithMessage("ToDo to delete not found");

            RuleFor(x => x.UserId)
            .MustAsync(async (x, cTkn) =>
            {
                return await dbContext.Users.AnyAsync(t => t.UserId == x, cTkn);
            })
            .WithName(nameof(ToDo.UserId))
            .WithMessage("User not found");
        }
    }
}
