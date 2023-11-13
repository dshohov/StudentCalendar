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
            var events = await Task.Run(()=> _context.UsersInEvents
            .Where(x => x.IdUser == userId)
            .Join(
                _context.Events,
                userInEvent => userInEvent.IdEvent,
                @event => @event.Id,
                (userInEvent, @event) => @event
            ));

            return events;
        }
    }
}
