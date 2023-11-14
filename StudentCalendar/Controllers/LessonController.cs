using Microsoft.AspNetCore.Mvc;
using StudentCalendar.IServices;
using StudentCalendar.Models;
using StudentCalendar.ViewModels;
using System.Text.RegularExpressions;

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

        public async Task<IActionResult> DeleteLesson(int lessonId, int groupId)
        {
            if(await _lessonService.DeleteLessonLogic(lessonId))
                return RedirectToAction("Index", "Lesson", new { idGroup = groupId });
            return RedirectToAction("Error","Home");
        }

        [HttpGet]
        public IActionResult EditLesson(int lessonId, int groupId)
        {
            
            return View(_lessonService.GetLessonEditViewModel(lessonId,groupId));
        }
        [HttpPost]
        public async Task<IActionResult> EditLessonAsync(LessonEditViewModel lessonVM)
        {
            if(await _lessonService.EditLessonLogic(lessonVM))
                return RedirectToAction("Index", "Lesson", new { idGroup = lessonVM.IdGrouop });
            return View();
        }
    }
}
