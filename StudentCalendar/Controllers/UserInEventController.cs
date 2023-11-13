using Microsoft.AspNetCore.Mvc;
using StudentCalendar.IServices;

namespace StudentCalendar.Controllers
{
    public class UserInEventController : Controller
    {
        private readonly IUserInEventService _userInEventService;
        public UserInEventController(IUserInEventService userInEventService)
        {
            _userInEventService = userInEventService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddUserInEvent(int eventId, string userId)
        {
            if(await _userInEventService.AddUserInEvent(eventId, userId))
                return RedirectToAction("CurrentEvents", "Event");
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> UserCalendar(string userId)
        {
            return View(await _userInEventService.GetUserEvents(userId));
        }
    }
}
