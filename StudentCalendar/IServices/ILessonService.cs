using Models;
using StudentCalendar.ViewModels;

namespace StudentCalendar.IServices
{
    public interface ILessonService
    {
        Task<IQueryable<Lesson>> GetLessonsByIdGroup(int idGroup);
        Task<string> GetNameGroupByIdGroup(int idGroup);
    }
}
