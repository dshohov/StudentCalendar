using StudentCalendar.IRepositories;
using StudentCalendar.IServices;
using Models;
using StudentCalendar.ViewModels;
using System.Security.Permissions;

namespace StudentCalendar.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IGroupRepository _groupRepository;
        public LessonService(ILessonRepository lessonRepository, IGroupRepository groupRepository)
        {
            _lessonRepository = lessonRepository;
            _groupRepository = groupRepository;
        }

        public async Task<bool> PostCreateLesson(Lesson lesson)
        {
            var lessonTime = new TimeSpan(1, 35, 0);
            lesson.EndTime = lesson.StartTime + lessonTime;
            return await _lessonRepository.AddLessonAsync(lesson);
        }
        public async Task<IQueryable<Lesson>> GetLessonsByIdGroup(int idGroup)
        {
            return await _lessonRepository.GetLessonsByGroupId(idGroup);
        }
        public async Task<string> GetNameGroupByIdGroup(int idGroup)
        {
            var group = await _groupRepository.GetGroupById(idGroup);
            return group.Name;
        }
        public async Task<bool> DeleteLessonLogic(int lessonId)
        {
            var lesson = await _lessonRepository.FindLessonById(lessonId);
            return await _lessonRepository.DeleteLesson(lesson);
        }
        public LessonEditViewModel GetLessonEditViewModel(int lessonId, int groupId)
        {
            return new LessonEditViewModel { Id = lessonId, IdGrouop = groupId };
        }
        public async Task<bool> EditLessonLogic(LessonEditViewModel lessonVM)
        {
            var lesson = await _lessonRepository.FindLessonById(lessonVM.Id);
            lesson.Name = lessonVM.Name;
            return await _lessonRepository.EditLesson(lesson);
        }
    }
}
