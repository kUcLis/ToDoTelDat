using MediatR;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Commands
{
    public record CreateUserCommand(string UserName) : IRequest<User>;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly ToDoContext _dbContext;

        public CreateUserCommandHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                UserName = request.UserName,
            };

            await _dbContext.Users.AddAsync(newUser, CancellationToken.None);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return newUser;
        }
    }
}
