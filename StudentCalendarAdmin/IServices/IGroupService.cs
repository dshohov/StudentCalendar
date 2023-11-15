using Models;

namespace StudentCalendarAdmin.IServices
{
    public interface IGroupService
    {
        Task<bool> CreateGroup(Group group);
        Task<IQueryable<Group>> GetGroupsAsync();
    }
}
