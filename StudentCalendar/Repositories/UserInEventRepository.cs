using Microsoft.EntityFrameworkCore;
using StudentCalendar.Data;
using StudentCalendar.IRepositories;
using StudentCalendar.Models;

namespace StudentCalendar.Repositories
{
    public class UserInEventRepository : IUserInEventRepository
    {
        private readonly ApplicationDbContext _context;
        public UserInEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddUserInEventAsync(UserInEvent userInEvent)
        {
            await _context.AddAsync(userInEvent);
            return await SaveAsync();
        }       

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }
        public async Task<bool> UserInEventExist(int eventId, string userId)
        {
            if(await _context.UsersInEvents.FirstOrDefaultAsync(x=>x.IdEvent == eventId && x.IdUser == userId) != null)
                return false; 
            return true;
        }

        public async Task<IQueryable<Event>> GetUserEvents(string userId)
        {
            var eventIds = await _context.UsersInEvents
             .Where(x => x.IdUser == userId)
             .Select(x => x.IdEvent)
             .ToListAsync();

            // Отримати список івентів за цими ідентифікаторами
            var events = _context.Events
                .Where(x => eventIds.Contains(x.Id));

            return events;
        }
    }
}
