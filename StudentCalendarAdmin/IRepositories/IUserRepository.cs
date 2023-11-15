using StudentCalendarAdmin.Models;

namespace StudentCalendarAdmin.IRepositories
{
    public interface IUserRepository
    {
        Task<IQueryable<AppUser>> GetNotConfirmUser();
        Task<bool> SaveAsync();
    }
}
