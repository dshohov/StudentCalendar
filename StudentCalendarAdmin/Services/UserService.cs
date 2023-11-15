using Microsoft.AspNetCore.Identity;
using StudentCalendarAdmin.IRepositories;
using StudentCalendarAdmin.IServices;
using StudentCalendarAdmin.Models;

namespace StudentCalendarAdmin.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        public UserService(IUserRepository userRepository,UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<IQueryable<AppUser>> GetNotConfirmUsers()
        {
            return await _userRepository.GetNotConfirmUser();
        }
        public async Task<bool> ConfirmUser(string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);
            if(user != null)
            {
                user.EmailConfirmed = true;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return true;
            }
            
            return false;
        }
    }
}
