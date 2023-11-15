using Microsoft.AspNetCore.Mvc;
using StudentCalendar.IServices;
using Models;
using StudentCalendar.ViewModels;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace StudentCalendar.Controllers
{
    [Authorize]
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
    }
}
