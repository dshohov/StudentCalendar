using Models;

namespace StudentCalendar.IServices
{
    public interface IEventService
    {     
        Task<IQueryable<Event>> GetCurrentEvents(string userId);
        
    }
}
