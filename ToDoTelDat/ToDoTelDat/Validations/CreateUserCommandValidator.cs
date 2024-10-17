using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Commands;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Validations
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(ToDoContext dbContext)
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithName(nameof(User.UserName))
            .WithMessage("UserName is required");

            RuleFor(x => x.UserName)
            .MinimumLength(3)
            .WithName(nameof(User.UserName))
            .WithMessage("UserName should be at lest 3 characters");

            RuleFor(x => x.UserName)
            .MaximumLength(30)
            .WithName(nameof(User.UserName))
            .WithMessage("UserName should be maximum 30 characters");



            RuleFor(x => x.UserName)
            .MustAsync(async (x, cTkn) =>
            {
                
                var isExisting = await dbContext.Users.AnyAsync(t => t.UserName == x, cTkn);

                if (isExisting)
                    return false;
                else return true;
            })
            .WithName(nameof(User.UserName))
            .WithMessage("UserName have to be unique");
        }
    }
}
