using StudentCalendar.IRepositories;
using StudentCalendar.IServices;
using StudentCalendar.Models;
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
    }
}
