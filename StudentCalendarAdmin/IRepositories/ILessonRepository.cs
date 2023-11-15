using Models;

namespace StudentCalendarAdmin.IRepositories
{
    public interface ILessonRepository
    {
        Task<bool> AddLessonAsync(Lesson lesson);
        Task<bool> DeleteLesson(Lesson lesson);
        Task<bool> EditLesson(Lesson lesson);
        Task<bool> SaveAsync();
        Task<Lesson> FindLessonById(int idLesson);
        Task<IQueryable<Lesson>> GetLessonsByGroupId(int groupId);
    }
}
