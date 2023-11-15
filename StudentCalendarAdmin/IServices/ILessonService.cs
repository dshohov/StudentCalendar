using Models;
using StudentCalendarAdmin.ViewModels;

namespace StudentCalendarAdmin.IServices
{
    public interface ILessonService
    {
        Task<bool> PostCreateLesson(Lesson lesson);
        Task<bool> DeleteLessonLogic(int lessonId);
        LessonEditViewModel GetLessonEditViewModel(int lessonId, int groupId);
        Task<bool> EditLessonLogic(LessonEditViewModel lessonVM);
        Task<IQueryable<Lesson>> GetLessonsByIdGroup(int idGroup);
        Task<string> GetNameGroupByIdGroup(int idGroup);
    }
}
