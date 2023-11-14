using Microsoft.AspNetCore.Identity;
using StudentCalendar.IRepositories;
using StudentCalendar.IServices;
using StudentCalendar.Models;

namespace StudentCalendar.Services
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
        public async Task<IQueryable<Event>> GetCurrentEvents(string userId)
        {
            var datetime = DateTime.Now;
            var user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                user.LoginTime = DateTime.Now;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return await _eventRepository.GetCurrentEvents(datetime, userId);
                }
            }
           
            return await _eventRepository.GetCurrentEvents(datetime,userId);
        }
    }
}
