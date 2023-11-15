using Microsoft.AspNetCore.Mvc;
using StudentCalendarAdmin.IServices;
using Models;
using Microsoft.AspNetCore.Authorization;

namespace StudentCalendarAdmin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }        
        public async Task<IActionResult> Index()
        {
            var events = await _eventService.GetAllEvents();
            return View(events);
        }
        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEventAsync(Event newEvent)
        {
            if(await _eventService.CreateEvent(newEvent)) 
                return RedirectToAction("Index");
            return View(newEvent);
        }        
    }
}
