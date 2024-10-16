using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Queries
{
    public record GetUserByUserNameQuery(string UserName) : IRequest<User?>;

    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, User?>
    {
        private readonly ToDoContext _dbContext;

        public GetUserByUserNameQueryHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User?> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users
               .FirstOrDefaultAsync(u => u.UserName == request.UserName, cancellationToken);
        }
    }
}
