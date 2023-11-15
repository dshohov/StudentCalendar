using Microsoft.EntityFrameworkCore;
using StudentCalendar.Data;
using StudentCalendar.IRepositories;
using Models;

namespace StudentCalendar.Repositories
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

        public async Task<Group> GetGroupById(int idGorup)
        {
            var group = await _context.Groups.FirstOrDefaultAsync(x => x.Id == idGorup);
            if(group != null)
                return group;
            throw new ArgumentNullException(nameof(group));
        }
    }
}
