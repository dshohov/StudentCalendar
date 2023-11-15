using Models;

namespace StudentCalendar.IRepositories
{
    public interface ILessonRepository
    {
        Task<IQueryable<Lesson>> GetLessonsByGroupId(int groupId);
    }
}
