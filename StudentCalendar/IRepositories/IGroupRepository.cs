using StudentCalendar.Models;

namespace StudentCalendar.IRepositories
{
    public interface IGroupRepository
    {
        Task<IQueryable<Group>> GetAll();
        Task<bool> AddGroupAsync(Group group);
        Task<bool> SaveAsync();
    }
}
