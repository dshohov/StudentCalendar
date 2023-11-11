using Microsoft.AspNetCore.Mvc;
using StudentCalendar.IServices;
using StudentCalendar.Models;

namespace StudentCalendar.Controllers
{
    public class LessonController : Controller
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        public async Task<IActionResult> Index(int idGroup)
        {
            ViewData["IdGroup"] = idGroup;
            ViewData["NameGroup"] = await _lessonService.GetNameGroupByIdGroup(idGroup);
            return View(await _lessonService.GetLessonsByIdGroup(idGroup));
        }

        [HttpGet]
        public IActionResult CreateLesson(int groupId,byte dayOfWeek, TimeSpan startTime)
        {
            var lesson = new Lesson() { IdGroup = groupId,DayOfWeek = dayOfWeek,StartTime = startTime };
            return View(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLessonAsync(Lesson lesson) 
        {
            if (await _lessonService.PostCreateLesson(lesson))
                return RedirectToAction("Index", "Lesson", new { idGroup = lesson.IdGroup });

            return View();
        }
    }
}
