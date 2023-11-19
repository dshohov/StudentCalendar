
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
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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
