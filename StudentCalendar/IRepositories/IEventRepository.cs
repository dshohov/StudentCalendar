using StudentCalendar.Models;

namespace StudentCalendar.IRepositories
{
    public interface IEventRepository
    {
        Task<bool> AddEventAsync(Event newEvent);
        Task<bool> SaveAsync();
        Task<IQueryable<Event>> GetAllAsync();
        Task<IQueryable<Event>> GetCurrentEvents(DateTime dateTime);
    }
}
