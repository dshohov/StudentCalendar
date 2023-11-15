using Models;

namespace StudentCalendarAdmin.IServices
{
    public interface IUserInEventService
    {
        Task<bool> AddUserInEvent(int eventId, string userId);
        Task<bool> RemoveUserInEvent(int idEvent, string idUser);
        Task<IQueryable<Event>> GetUserEvents(string userId, int? mounth);
    }
}
