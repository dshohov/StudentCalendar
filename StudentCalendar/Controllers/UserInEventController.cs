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
                return RedirectToAction("CurrentEvents", "Event",new { userId });
            return RedirectToAction("Error","Home");
        }

        public async Task<IActionResult> UserCalendar(string userId, int? mounth)
        {
            return View(await _userInEventService.GetUserEvents(userId,mounth));
        }
        public async Task<IActionResult> RemoveEventInCalendar(int idEvent, string idUser)
        {
            await _userInEventService.RemoveUserInEvent(idEvent, idUser);
                return RedirectToAction("UserCalendar", "UserInEvent", new { userId = idUser,mounth = DateTime.Now.Month }); ;
        }
    }
}
