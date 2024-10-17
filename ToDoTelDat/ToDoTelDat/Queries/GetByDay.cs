using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Entities;

namespace ToDoTelDat.Queries
{
    public record GetByDayQuery(DateTime Day, int UserId) : IRequest<IList<ToDo>>;

    public class GetByDayQueryHandler : IRequestHandler<GetByDayQuery, IList<ToDo>>
    {
        private readonly ToDoContext _dbContext;

        public GetByDayQueryHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<ToDo>> Handle(GetByDayQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.ToDoes
                .Include(t => t.User)
                .Where(t => t.UserId == request.UserId && t.StartDate.Date == request.Day.Date)
                .ToListAsync(cancellationToken);
        }
    }
}
