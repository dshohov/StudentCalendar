using Microsoft.EntityFrameworkCore;
using StudentCalendarAdmin.Data;
using StudentCalendarAdmin.IRepositories;
using Models;

namespace StudentCalendarAdmin.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext _context;
        public GroupRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Group>> GetAll()
        {
            return await Task.Run(()=> _context.Groups);
        }
        public async Task<bool> AddGroupAsync(Group group)
        {
            await _context.AddAsync(group);
            return await SaveAsync();
        }
        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<Group> GetGroupById(int idGorup)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == idGorup);
            if(group != null)
                return group;
            throw new ArgumentNullException(nameof(group));
        }
    }
}
