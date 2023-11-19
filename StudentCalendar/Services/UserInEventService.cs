using Microsoft.EntityFrameworkCore;
using StudentCalendar.IRepositories;
using StudentCalendar.IServices;
using Models;
using System.Runtime.CompilerServices;

namespace StudentCalendar.Services
{
    public class UserInEventService : IUserInEventService
    {
        private readonly IUserInEventRepository _userInEventRepository;
        public UserInEventService (IUserInEventRepository userInEventRepository)
        {
            _userInEventRepository = userInEventRepository;
        }

        public async Task<bool> AddUserInEvent(int eventId, string userId)
        {
            if(await _userInEventRepository.UserInEventExist(eventId, userId))
            {
                var userInEvent = new UserInEvent { IdEvent = eventId, IdUser = userId, Join = true };
                return await _userInEventRepository.AddUserInEventAsync(userInEvent);
            }
            return false;
        }

        public async Task<IQueryable<Event>> GetUserEvents(string userId,int? mounth)
        {
            var userEvents = await _userInEventRepository.GetUserEvents(userId);
            if (mounth == null)
                mounth = DateTime.Now.Month;
            var result = userEvents.Where(x=>x.DateTime.Month == mounth && x.DateTime.Year == DateTime.Now.Year);
            return result;
        }

        public async Task<bool> RemoveUserInEvent(int idEvent, string idUser)
        {
            var userInEvent = await _userInEventRepository.FindUserInEventByIdEvent(idEvent, idUser);
            return await _userInEventRepository.RemoveUserInEventAsync(userInEvent);
        }
    }
}
