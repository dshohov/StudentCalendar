using Microsoft.EntityFrameworkCore;
using StudentCalendar.Data;
using StudentCalendar.IRepositories;
using Models;

namespace StudentCalendar.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<Lesson>> GetLessonsByGroupId(int groupId)
        {
            return await Task.Run(() => _context.Lessons.Where(x => x.IdGroup == groupId));
        }
    }
}
