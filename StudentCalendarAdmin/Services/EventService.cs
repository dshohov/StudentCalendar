
using Microsoft.AspNetCore.Identity;
using StudentCalendarAdmin.IRepositories;
using StudentCalendarAdmin.IServices;
using Models;
using StudentCalendarAdmin.Models;

namespace StudentCalendarAdmin.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        private readonly UserManager<AppUser> _userManager;
        public EventService(IEventRepository eventRepository, UserManager<AppUser> userManager)
        {
            _eventRepository = eventRepository;
            _userManager = userManager;
        }

        public async Task<bool> CreateEvent(Event newEvent)
        {
            newEvent.DateCreate = DateTime.Now;
            return await _eventRepository.AddEventAsync(newEvent);
        }

        public async Task<IQueryable<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllAsync();
        }        
    }
}
