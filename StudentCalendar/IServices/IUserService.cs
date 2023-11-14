using StudentCalendar.Models;

namespace StudentCalendar.IServices
{
    public interface IUserService
    {
        Task<IQueryable<AppUser>> GetNotConfirmUsers();
        Task<bool> ConfirmUser(string idUser);
    }
}
