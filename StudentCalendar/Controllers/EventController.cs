using Microsoft.AspNetCore.Mvc;
using StudentCalendar.IServices;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace StudentCalendar.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }
        public async Task<IActionResult> CurrentEvents(string userId)
        {
            var currentEvent = await _eventService.GetCurrentEvents(userId);
            return View(currentEvent);
        }
    }
}
