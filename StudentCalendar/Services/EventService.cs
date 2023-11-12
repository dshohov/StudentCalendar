using StudentCalendar.IRepositories;
using StudentCalendar.IServices;
using StudentCalendar.Models;

namespace StudentCalendar.Services
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
            return await _eventRepository.AddEventAsync(newEvent);
        }

        public async Task<IQueryable<Event>> GetAllEvents()
        {
            return await _eventRepository.GetAllAsync();
        }
        public async Task<IQueryable<Event>> GetCurrentEvents()
        {
            var datetime = DateTime.Now;
            return await _eventRepository.GetCurrentEvents(datetime);
        }
    }
}
