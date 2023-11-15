using StudentCalendarAdmin.Models;

namespace StudentCalendarAdmin.IServices
{
    public interface IUserService
    {
        Task<IQueryable<AppUser>> GetNotConfirmUsers();
        Task<bool> ConfirmUser(string idUser);
    }
}
