using StudentCalendar.Models;

namespace StudentCalendar.IServices
{
    public interface IUserInEventService
    {
        Task<bool> AddUserInEvent(int eventId, string userId);
        Task<IQueryable<Event>> GetUserEvents(string userId, int? mounth);
    }
}
