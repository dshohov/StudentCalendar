﻿using StudentCalendar.Models;

namespace StudentCalendar.IRepositories
{
    public interface IUserRepository
    {
        Task<IQueryable<AppUser>> GetNotConfirmUser();
        Task<bool> SaveAsync();
    }
}
