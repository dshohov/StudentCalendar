using Microsoft.EntityFrameworkCore;
using StudentCalendar.Data;
using StudentCalendar.IRepositories;
using StudentCalendar.Models;

namespace StudentCalendar.Repositories
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
            // userId - ідентифікатор поточного користувача
            var eventsNotJoined = await Task.Run(() => _context.Events
                .Where(e => !_context.UsersInEvents.Any(ue => ue.IdUser == userId && ue.IdEvent== e.Id)));

            return await Task.Run(() => eventsNotJoined.Where(x=>x.DateTime >= dateTime));
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<Event> GetlastEvent()
        {
            return await _context.Events.OrderBy(x => x.DateCreate).LastAsync();
        }
    }
}
