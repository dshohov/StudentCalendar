using Microsoft.EntityFrameworkCore;
using StudentCalendar.Data;
using StudentCalendar.IRepositories;
using Models;

namespace StudentCalendar.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Event>> GetCurrentEvents(DateTime dateTime, string userId)
        {
            return await Task.Run(() => 
            _context.Events
                            .Where(e => !_context.UsersInEvents.Any(ue => ue.IdUser == userId && ue.IdEvent == e.Id))
                            .Where(x=>x.DateTime >= dateTime));
        }
        public async Task<Event> GetlastEvent()
        {
            return await _context.Events.OrderBy(x => x.DateCreate).LastOrDefaultAsync();
        }
    }
}
