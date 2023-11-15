
using StudentCalendarAdmin.IRepositories;
using StudentCalendarAdmin.IServices;
using Models;
using StudentCalendarAdmin.Repositories;

namespace StudentCalendarAdmin.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        public GroupService(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<bool> CreateGroup(Group group)
        {
            if(group != null)
                return await _groupRepository.AddGroupAsync(group);
            return false;
        } 
        public async Task<IQueryable<Group>> GetGroupsAsync()
        {
            return await _groupRepository.GetAll();
        }
    }
}
