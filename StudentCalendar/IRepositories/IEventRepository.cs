using Models;

namespace StudentCalendar.IRepositories
{
    public interface IEventRepository
    {
        Task<IQueryable<Event>> GetCurrentEvents(DateTime dateTime, string userId);
        Task<Event> GetlastEvent();
       
    }
}
