﻿using Microsoft.EntityFrameworkCore;
using StudentCalendarAdmin.IRepositories;
using StudentCalendarAdmin.IServices;
using Models;
using System.Runtime.CompilerServices;

namespace StudentCalendarAdmin.Services
{
    public class UserInEventService : IUserInEventService
    {
        private readonly IUserInEventRepository _userInEventRepository;
        private readonly IEventRepository _eventRepository;
        public UserInEventService (IUserInEventRepository userInEventRepository, IEventRepository eventRepository)
        {
            _userInEventRepository = userInEventRepository;
            _eventRepository = eventRepository;
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