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
        public async Task<IQueryable<Event>> GetCurrentEvents(DateTime dateTime)
        {
            return await Task.Run(() => _context.Events.Where(x=>x.DateTime >= dateTime));
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
    }
}
