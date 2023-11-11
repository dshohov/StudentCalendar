using StudentCalendar.Models;

namespace StudentCalendar.IRepositories
{
    public interface ILessonRepository
    {
        Task<bool> AddLessonAsync(Lesson lesson);
        Task<bool> SaveAsync();
        Task<IQueryable<Lesson>> GetLessonsByGroupId(int groupId);
    }
}
