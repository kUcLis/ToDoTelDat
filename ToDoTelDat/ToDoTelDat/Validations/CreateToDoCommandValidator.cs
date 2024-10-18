using FluentValidation;
using ToDoTelDat.Commands;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Validations
{
    public class CreateToDoCommandValidator : AbstractValidator<CreateToDoCommand>
    {
        public CreateToDoCommandValidator()
        {

            RuleFor(x => x.ToDo.TaskName)
                .NotEmpty()
                .WithName(nameof(ToDo.TaskName))
                .WithMessage("TaskName is required");

            RuleFor(x => x.ToDo.TaskName)
                .MaximumLength(100)
                .WithName(nameof(ToDo.TaskName))
                .WithMessage("TaskName maximum Length is 100");

            RuleFor(x => x.ToDo.TaskName)
                    .MinimumLength(3)
                    .WithName(nameof(ToDo.TaskName))
                    .WithMessage("TaskName minimum Length is 3");

            RuleFor(x => x.ToDo.UserId)
                   .NotEmpty()
                   .WithName(nameof(ToDo.UserId))
                   .WithMessage("UserId is required");

            RuleFor(x => x.ToDo.StartDate)
                   .NotEmpty()
                   .WithName(nameof(ToDo.StartDate))
                   .WithMessage("StartDate is required");

            RuleFor(x => x.ToDo.StartDate)
                   .Must(x => x.AddHours(2) > DateTime.Now)
                   .WithName(nameof(ToDo.StartDate))
                   .WithMessage("StartDate Must start in the future");


        }
    }
}
