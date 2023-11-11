using Microsoft.EntityFrameworkCore;
using StudentCalendar.Data;
using StudentCalendar.IRepositories;
using StudentCalendar.Models;

namespace StudentCalendar.Repositories
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _context;
        public LessonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddLessonAsync(Lesson lesson)
        {
            await _context.AddAsync(lesson);
            return await SaveAsync();
        }

        public async Task<bool> DeleteLesson(Lesson lesson)
        {
            await Task.Run(()=>_context.Remove(lesson));
            return await SaveAsync();
        }
        public async Task<bool> EditLesson(Lesson lesson)
        {
            await Task.Run(()=> _context.Lessons.Update(lesson));
            return await SaveAsync();
        }

        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

        public async Task<Lesson> FindLessonById(int idLesson)
        {
            return await _context.Lessons.FindAsync(idLesson);
        }
        public async Task<IQueryable<Lesson>> GetLessonsByGroupId(int groupId)
        {
            return await Task.Run(() => _context.Lessons.Where(x => x.IdGroup == groupId));
        }
    }
}
