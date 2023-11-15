using Models;

namespace StudentCalendarAdmin.IRepositories
{
    public interface IUserInEventRepository
    {
        Task<bool> AddUserInEventAsync(UserInEvent userInEvent);
        Task<bool> RemoveUserInEventAsync(UserInEvent userInEvent);
        Task<bool> SaveAsync();
        Task<bool> UserInEventExist(int eventId, string userId);
        Task<IQueryable<Event>> GetUserEvents(string userId);
        Task<UserInEvent> FindUserInEventByIdEvent(int idEvent, string idUser);
    }
}
