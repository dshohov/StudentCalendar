using Microsoft.EntityFrameworkCore;
using StudentCalendarAdmin.Data;
using StudentCalendarAdmin.IRepositories;
using Models;

namespace StudentCalendarAdmin.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddEventAsync(Event newEvent)
        {
            await _context.AddAsync(newEvent);
            return await SaveAsync();
        }

        public async Task<IQueryable<Event>> GetAllAsync()
        {
            return await Task.Run(()=>_context.Events.OrderByDescending(x=>x.DateTime));
        }
        public async Task<IQueryable<Event>> GetCurrentEvents(DateTime dateTime, string userId)
        {
            return await Task.Run(() => 
            _context.Events
                            .Where(e => !_context.UsersInEvents.Any(ue => ue.IdUser == userId && ue.IdEvent == e.Id))
                            .Where(x=>x.DateTime >= dateTime));
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<Event> GetlastEvent()
        {
            return await _context.Events.OrderBy(x => x.DateCreate).LastOrDefaultAsync();
        }
    }
}
