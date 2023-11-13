using StudentCalendar.Models;

namespace StudentCalendar.IRepositories
{
    public interface IUserInEventRepository
    {
        Task<bool> AddUserInEventAsync(UserInEvent userInEvent);
        Task<bool> SaveAsync();
        Task<bool> UserInEventExist(int eventId, string userId);
        Task<IQueryable<Event>> GetUserEvents(string userId);
    }
}
