using Microsoft.AspNetCore.Identity;
using StudentCalendarAdmin.Data;
using StudentCalendarAdmin.IRepositories;
using StudentCalendarAdmin.Models;
using System.Runtime.CompilerServices;

namespace StudentCalendarAdmin.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository (ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<AppUser>> GetNotConfirmUser()
        {
            return await Task.Run(()=>_context.Users.Where(x => x.EmailConfirmed == false));
        }
        public async Task<bool> SaveAsync()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0 ? true : false;
        }

    }
}
