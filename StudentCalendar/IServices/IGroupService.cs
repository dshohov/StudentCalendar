using StudentCalendar.Models;

namespace StudentCalendar.IServices
{
    public interface IGroupService
    {
        Task<bool> CreateGroup(Group group);
        Task<IQueryable<Group>> GetGroupsAsync();
    }
}
