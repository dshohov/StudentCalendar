using Models;

namespace StudentCalendarAdmin.IRepositories
{
    public interface IEventRepository
    {
        Task<bool> AddEventAsync(Event newEvent);
        Task<bool> SaveAsync();
        Task<IQueryable<Event>> GetAllAsync();
       
    }
}
