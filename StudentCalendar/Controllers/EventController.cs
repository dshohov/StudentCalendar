using Microsoft.AspNetCore.Mvc;
using StudentCalendar.IServices;
using StudentCalendar.Models;

namespace StudentCalendar.Controllers
{
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

        public async Task<IActionResult> CurrentEvents()
        {
            var currentEvent = await _eventService.GetCurrentEvents();
            return View(currentEvent);
        }
        
    }
}
