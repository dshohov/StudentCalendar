using Models;

namespace StudentCalendar.IServices
{
    public interface IEventService
    {
        Task<bool> CreateEvent(Event newEvent);
        Task<IQueryable<Event>> GetAllEvents();
        Task<IQueryable<Event>> GetCurrentEvents(string userId);
        
    }
}
