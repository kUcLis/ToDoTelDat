using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoTelDat.Entities;
using ToDoTelDat.Models;

namespace ToDoTelDat.Queries
{
    public record GetByDayQuery(DateTime Day, int UserId) : IRequest<IList<ToDoDto>>;

    public class GetByDayQueryHandler : IRequestHandler<GetByDayQuery, IList<ToDoDto>>
    {
        private readonly ToDoContext _dbContext;

        public GetByDayQueryHandler(ToDoContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<ToDoDto>> Handle(GetByDayQuery request, CancellationToken cancellationToken)
        {

            return await _dbContext.ToDoes
                .Include(t => t.User)
                .Where(t => t.UserId == request.UserId && t.StartDate.Date == request.Day.Date)
                .Select(t => new ToDoDto
                {
                    ToDoId = t.ToDoId,
                    TaskName = t.TaskName,
                    Description = t.Description,
                    StartDate = t.StartDate,
                    UserId = request.UserId,
                    IsDisabled = DateTime.Now > t.StartDate,
                    TurnAlarm = (DateTime.Now < t.StartDate && (t.StartDate - DateTime.Now).TotalMinutes < 30.0)
                })
                .OrderBy(t => t.StartDate)
                .ToListAsync(cancellationToken);
        }
    }
}
