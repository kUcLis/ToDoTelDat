using MediatR;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Commands
{
    public record CreateUserCommand(string UserName) : IRequest<int>;

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly ToDoContext _dbContext;

        public CreateUserCommandHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                UserName = request.UserName,
            };

            await _dbContext.Users.AddAsync(newUser, CancellationToken.None);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return newUser.UserId;
        }
    }
}
