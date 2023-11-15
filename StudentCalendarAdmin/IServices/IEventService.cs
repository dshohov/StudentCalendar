using Models;

namespace StudentCalendarAdmin.IServices
{
    public interface IEventService
    {
        Task<bool> CreateEvent(Event newEvent);
        Task<IQueryable<Event>> GetAllEvents();
        
    }
}
