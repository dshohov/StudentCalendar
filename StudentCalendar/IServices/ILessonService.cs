using StudentCalendar.Models;

namespace StudentCalendar.IServices
{
    public interface ILessonService
    {
        Task<bool> PostCreateLesson(Lesson lesson);
        Task<IQueryable<Lesson>> GetLessonsByIdGroup(int idGroup);
        Task<string> GetNameGroupByIdGroup(int idGroup);
    }
}
